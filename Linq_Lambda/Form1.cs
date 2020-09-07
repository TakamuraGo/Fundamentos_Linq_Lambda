using Linq_Lambda.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Linq_Lambda
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Simular una base de datos : llenando datos las clases.
            ObtenerData();
        }

        List<Cabecera> cabeceras = null;
        List<Cabecera> CabeceraFiltro = null;
        private void ObtenerData()
        {
            //Lista con clases Cabecera - Detalle
            cabeceras = new List<Cabecera>
            {
                new Cabecera
                {
                    IdCabecera= 1,NroDocumento= "001", Fecha= DateTime.Now, Total= 100,
                    Detalles= new List<Cabecera_Detalle>
                    {
                        new Cabecera_Detalle
                        {
                            IdCabecera_Detalle= 1,IdCabecera=1, Codigo="cod01",Descripcion="Celular",Cantidad=1,Total=100
                        }
                    }
                },
                new Cabecera
                {
                    IdCabecera= 2,NroDocumento= "002", Fecha= DateTime.Now, Total= 150,
                    Detalles= new List<Cabecera_Detalle>
                    {
                        new Cabecera_Detalle
                        {
                            IdCabecera_Detalle= 1,IdCabecera=2, Codigo="cod01",Descripcion="Celular",Cantidad=1,Total=50
                        },
                        new Cabecera_Detalle
                        {
                            IdCabecera_Detalle= 2,IdCabecera=2, Codigo="cod01",Descripcion="Celular",Cantidad=1,Total=50
                        }
                    }
                }
            };

        }



        private void Mostrar_Opciones_Linq()
        {
            //Linq de enteros opc1 - la misma jugada es para string
            List<int> numeros = new List<int>()
            {
                1,2,3,4,5
            };

            //opc2
            List<int> numeros2 = new List<int>();
            numeros2.Add(1);
            numeros2.Add(2);
            numeros2.Add(3);

            //Linq de Fechas

            List<DateTime> dateTimes = new List<DateTime>()
            {
                DateTime.Now, new DateTime(2020,09,06)
            };


            foreach (var item in dateTimes)
            {
                MessageBox.Show(item.ToString());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //SINTAXIS DE METODO :Expresion Lamba - Es una forma para definir funciones anonimas que no tienen nombre.
            //Cuando usemos LInq siempre nos va devolver un objeto IEnumerable 
            CabeceraFiltro = cabeceras.Where(x => x.NroDocumento.Equals("002")).ToList();

            var ordenadoMenorAMayor = cabeceras.OrderByDescending(x => x.NroDocumento).ToList();
            var sumaTotal = cabeceras.Sum(x => x.Total);
            var MaxTotal = cabeceras.Max(x => x.Total);
            var media = cabeceras.Average(x => x.Total);
            var todosAprobados = cabeceras.All(x => x.Total >= 5);

            //SINTAXIS DE CONSULTA o integrada : Similar al SQL
            CabeceraFiltro = (from x in cabeceras
                              where x.NroDocumento.Equals("001")
                              select x
                              ).ToList();
            
            MessageBox.Show(media.ToString());
            //dataGridView1.DataSource = sumaNotas.ToString();
            dataGridView1.Refresh();
        }
    }
}
