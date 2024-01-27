using System;
using System.Collections.Generic;

namespace Controller.Enumerations
{
    public sealed class Locacion
    {
        private Locacion() { }

        private static readonly Dictionary<string, Type> ubicaciones = new Dictionary<string, Type>
        {{                           "Loja"    ,    typeof(CiudadesLoja)                        },
        {                            "Napo"    ,    typeof(CiudadesNapo)                        },
        {                           "Cañar"    ,    typeof(CiudadesCanar)                       },
        {                           "Azuay"    ,    typeof(CiudadesAzuay)                       },
        {                          "El_Oro"    ,    typeof(CiudadesElOro)                       },
        {                          "Carchi"    ,    typeof(CiudadesCarchi)                      },
        {                          "Guayas"    ,    typeof(CiudadesGuayas)                      },
        {                          "Manabí"    ,    typeof(CiudadesManabi)                      },
        {                         "Bolivar"    ,    typeof(CiudadesBolivar)                     },
        {                         "Pastaza"    ,    typeof(CiudadesPastaza)                     },
        {                        "Los_Ríos"    ,    typeof(CiudadesLosRios)                     },
        {                        "Imbabura"    ,    typeof(CiudadesImbabura)                    },
        {                        "Orellana"    ,    typeof(CiudadesOrellana)                    },
        {                        "Cotopaxi"    ,    typeof(CiudadesCotopaxi)                    },
        {                       "Pichincha"    ,    typeof(CiudadesPichincha)                   },
        {                       "Galápagos"    ,    typeof(CiudadesGalapagos)                   },
        {                       "Sucumbios"    ,    typeof(CiudadesSucumbios)                   },
        {                      "Esmeraldas"    ,    typeof(CiudadesEsmeraldas)                  },
        {                      "Chimborazo"    ,    typeof(CiudadesChimborazo)                  },
        {                      "Tungurahua"    ,    typeof(CiudadesTungurahua)                  },
        {                     "Santa_Elena"    ,    typeof(CiudadesSantaElena)                  },
        {                 "Morona_Santiago"    ,    typeof(CiudadesMoronaSantiago)              },
        {                "Zamora_Chinchipe"    ,    typeof(CiudadesZamoraChinchipe)             },
        {  "Santo_domingo_de_los_Tsáchilas"    ,    typeof(CiudadesSantoDomindoDeLosTsachilas) }};

        public static string[] Ciudades
        {
            get
            {
                List<string> array = new List<string>();

                foreach (string provincia in ubicaciones.Keys)
                {
                    array.AddRange(CitiesByRegion(provincia));
                }

                array.Sort();

                return array.ToArray();
            }
        }

        public static string[] Provincias
        {
            get
            {
                List<string> array = new List<string>(ubicaciones.Keys);

                for (int i = 0; i < array.Count; i++)
                    array[i] = array[i].Replace("_", " ");

                array.Sort();

                return array.ToArray();
            }
        }

        public static string[] CitiesByRegion(string region)
        {
            region = region.Replace(" ", "_");

            return TypeToArray(ubicaciones[region]);
        }

        public static string[] TypeToArray(Type type)
        {
            List<string> array = new List<string>();

            foreach (var item in Enum.GetValues(type))
            {
                string e = item.ToString().Replace("_", " ");

                array.Add(e);
            }
            
            array.Sort();

            return array.ToArray();
        }
    }
}
