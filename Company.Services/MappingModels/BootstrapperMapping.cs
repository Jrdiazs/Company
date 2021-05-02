using AutoMapper;
using Company.Services.Profiles;

namespace Company.Services.MappingModels
{
    /// <summary>
    /// BootstrapperMapping, configuracion de todos los perfiles automapper
    /// </summary>
    public static class BootstrapperMapping
    {
        /// <summary>
        /// IMapper
        /// </summary>
        private static IMapper _mapper;
        /// <summary>
        /// Configuraciona actual
        /// </summary>
        private static MapperConfiguration _config;

        /// <summary>
        /// Configuraciona actual
        /// </summary>
        public static MapperConfiguration Config
        {
            get
            {
                if (_config == null)
                {
                    _config = CreateConfig();
                }
                return _config;
            }
        }

        /// <summary>
        /// Auto Mapper
        /// </summary>
        public static IMapper Mapper
        {
            get
            {
                if (_mapper != null)
                    return _mapper;
                else
                {
                    _mapper = CreateMapper();
                    return Mapper;
                }
            }
        }

        /// <summary>
        /// Se inicial el automapper
        /// </summary>
        /// <param name="mapper"></param>
        public static void SetMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Crea el automapper
        /// </summary>
        /// <returns></returns>
        public static IMapper CreateMapper()
        {
            _mapper = Config.CreateMapper();
            return _mapper;
        }

        /// <summary>
        /// Inicializa la configuracion
        /// </summary>
        /// <returns></returns>
        public static MapperConfiguration CreateConfig()
        {
            _config = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new UserAppProfile());
            });

            return _config;
        }
    }
}