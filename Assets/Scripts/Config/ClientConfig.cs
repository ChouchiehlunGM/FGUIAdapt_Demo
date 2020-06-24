using System;
using ConceptDemo.Scripts.Config;
using UnityEngine;

namespace Config
{
    [Serializable]
    public static class ClientConfig
    {
        private static GlobalConfig _globalConfig;

        public static GlobalConfig GlobalConfig => _globalConfig != null
            ? _globalConfig
            : _globalConfig = Resources.Load<GlobalConfig>( "Data/GlobalConfig" );
    }
}