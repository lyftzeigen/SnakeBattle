namespace Launcher
{
    public static class Settings
    {
        private static int fieldWidth;
        private static int fieldHeight;
        private static int blokSize;
        private static int terrainDomainPower;

        public static int FieldWidth
        {
            get { return fieldWidth; }
            set { fieldWidth = value; }
        }

        public static int FieldHeight
        {
            get { return fieldHeight; }
            set { fieldHeight = value; }
        }

        public static int BlokSize
        {
            get { return blokSize; }
            set { blokSize = value; }
        }

        public static int TerrainDomainNumber { get; set; }

        public static int TerrainDomainPower
        {
            get { return terrainDomainPower; }
            set { terrainDomainPower = value < 1 ? 1 : value; }
        }


        public static int FoodCount { get; set; }
        public static int RenderDelay { get; set; }
        public static int UpdateDeleay { get; set; }
    }
}