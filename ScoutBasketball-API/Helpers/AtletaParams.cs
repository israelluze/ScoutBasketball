using System;

namespace ScoutBasketball_API.Helpers
{
    public class AtletaParams
    {
        private const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1 ;
        private int pageSize = 10;

        public int PageSize
        {
            get { return pageSize;}
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value;}
        }


        public int AtletaId { get; set; }
        public int NumeroMin { get; set; } = 0;
        public int NumeroMax { get; set; } = 100;        
        public int AnoMin{ get; set; }  = 1950;
        public int Anomax{ get; set; }  = 2099;
        public string Posicao { get; set; }  
        public string OrderBy { get; set; }  

        
        

        
    }
}