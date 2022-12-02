using System;

namespace MediaCatalog
{
    public class Item
    {
        /// <summary> Уникальный идентификатор </summary>
        public Guid Id { get; set; }

        /// <summary> Наименование </summary>
        public string Name { get; set; }

        /// <summary> Тэг </summary>
        public string Tag { get; set; }

        /// <summary> Путь к файлу </summary>
        public string Path { get; set; }

        /// <summary> Тип мультимедиа </summary>
        public EItemType Type { get; set; }

        /// <summary> Тип мультимедиa во множественном числе </summary>
        public EItemTypes Types { get=>Type.ToTypes(); } 
    }
}
