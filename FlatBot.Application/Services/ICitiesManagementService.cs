﻿namespace FlatBot.Application.Services
{
    public interface ICitiesManagementService
    {
        public void TestFunc();
        public void AddSourceToCity(string city, int source);
        public void AddSourceToCity(string city, List<int> source);
        public void AddCitiesToSource(int source, List<string> cities);
        public void RemoveCity(string city);
        public void RemoveCitySource(string city, int source);
        public void RemoveCitySource(string city, List<int> source);

    }
}
