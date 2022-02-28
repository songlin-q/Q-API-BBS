using Q.API.IRespostories;
using Q.API.IServices;
using Q.API.Respostories;
using System;

namespace Q.API.Services
{
    public class CalculateSerivce: ICalculateService
    {
        ICalculateRespostories _calculateRespostories = new CalculateRespostories();

        public int Sum(int i,int j)
        {
           return _calculateRespostories.Sum(i,j);
        }
    }
}
