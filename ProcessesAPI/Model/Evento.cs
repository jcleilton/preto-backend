using System;

namespace ProcessesAPI.Model
{
    public class Evento
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public DateTime data { get; set; }
        public int is_aberto { get; set; }
        public string logradouro { get; set; }
        public string numero_casa { get; set; }
        public string cidade { get; set; }
        public string uf { get; set; }
        public string pais { get; set; }
        public string cep { get; set; }
        public string observacao { get; set; }

       

        public Evento()
        {
            
        }

    }
}