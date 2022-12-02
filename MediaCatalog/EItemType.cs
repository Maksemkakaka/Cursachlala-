using System.Collections;

namespace MediaCatalog
{
    public enum EItemType
    {
        СТИКЕР,
        ГИФКА,
        МЭМ
    }
    public enum EItemTypes
    {
        ВСЕ,
        СТИКЕРЫ,
        ГИФКИ,
        МЭМЫ
    }






    public static class ExTypes
    {

        public static EItemTypes ToTypes(this EItemType type)
        {
            switch (type)
            {
                case EItemType.СТИКЕР: return EItemTypes.СТИКЕРЫ;
                case EItemType.ГИФКА: return EItemTypes.ГИФКИ;
                case EItemType.МЭМ: return EItemTypes.МЭМЫ;
                default: return EItemTypes.ВСЕ;
            }
        }

        public static EItemType ToType(this EItemTypes type)
        {
            switch (type)
            {
                case EItemTypes.СТИКЕРЫ: return EItemType.СТИКЕР;
                case EItemTypes.ГИФКИ: return EItemType.ГИФКА;
                case EItemTypes.МЭМЫ: return EItemType.МЭМ;
                default: return default;
            }
        }
    }
}
