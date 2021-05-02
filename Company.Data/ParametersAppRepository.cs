using Company.Models;
using System;
using System.Linq;

namespace Company.Data
{
    public class ParametersAppRepository : GenericRepository<ParametersApp>, IParametersAppRepository, IDisposable
    {
        public ParametersAppRepository(CompanyDatabaseContext dbContext) : base(dbContext)
        {
        }

        public T GetValueFromKey<T>(string keyParameter)
        {
            try
            {
                T value = default;
                var parameter = FilterData(x => x.ParameterKey == keyParameter).FirstOrDefault();
                if (parameter == null) return value;

                switch (Type.GetTypeCode(typeof(T)))
                {
                    case TypeCode.Int32:
                        value = (T)Convert.ChangeType(parameter.ValueNumber, typeof(T));
                        break;

                    case TypeCode.Int64:
                        value = (T)Convert.ChangeType(parameter.ValueBingInt, typeof(T));
                        break;

                    case TypeCode.String:
                        value = (T)Convert.ChangeType(parameter.ValueString, typeof(T));
                        break;

                    case TypeCode.Boolean:
                        value = (T)Convert.ChangeType(parameter.ValueBoleano, typeof(T));
                        break;

                    case TypeCode.DateTime:
                        value = (T)Convert.ChangeType(parameter.ValueDateTime, typeof(T));
                        break;

                    default:

                        if (typeof(T) == typeof(int?))
                            value = (T)Convert.ChangeType(parameter.ValueNumber, typeof(T));
                        else
                        if (typeof(T) == typeof(long?))
                            value = (T)Convert.ChangeType(parameter.ValueBingInt, typeof(T));
                        else
                        if (typeof(T) == typeof(DateTime?))
                            value = (T)Convert.ChangeType(parameter.ValueDateTime, typeof(T));
                        else
                        if (typeof(T) == typeof(bool?))
                            value = (T)Convert.ChangeType(parameter.ValueBoleano, typeof(T));
                        else
                        if (typeof(T) == typeof(Guid) || typeof(T) == typeof(Guid?))
                            value = (T)Convert.ChangeType(parameter.ValueGuid, typeof(T));

                        break;
                }

                return value;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    public interface IParametersAppRepository : IGenericRepository<ParametersApp>, IDisposable
    {
        T GetValueFromKey<T>(string keyParameter);
    }
}