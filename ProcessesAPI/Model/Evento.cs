using System;

namespace ProcessesAPI.Model
{
    class Evento
    {
        public int id { get; set; }
        public string nome { get; set; }
        public DateTime data { get; set; }
        public bool is_aberto { get; set; }
       

        public Evento()
        {
            
        }

    }
}