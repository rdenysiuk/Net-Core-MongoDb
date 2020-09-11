namespace CarXUnitIntegration.Utility
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root;// $"{Root}/{Version}";

        public static class Car
        {
            public const string GetAll = Base + "/Car";
            public const string Get = Base + "/Car/{carId}";
            public const string Update = Base + "/Car/{carId}";
            public const string Delete = Base + Base + "/Car/{carId}";
            public const string Create = Base + "/Car";
        }
    }
}
