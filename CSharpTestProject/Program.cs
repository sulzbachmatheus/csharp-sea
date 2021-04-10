using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpTestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite as informações no formato a seguir: 'Regular: 16Mar2020(mon), 17Mar2020(tues), 18Mar2020(wed)':");
            var info = Console.ReadLine();
            int index = info.IndexOf(':');

            string tipoParticipante = "";
            tipoParticipante = info.Substring(0, index);
            
            string datas = "";
            datas = info.Substring(index + 1);
            
            var listaDatas = datas.Split(',').ToList();            
            
            List<string> dias = new List<string>();
            char[] charsToTrim = { '(', ')'};

            foreach (var item in listaDatas) {
                //trim to remove ( ) chars
                dias.Add(item.Substring(10).Trim(charsToTrim));          
            }     

            EncontrarHotelMaisBarato(dias, tipoParticipante);    
        }

        static string EncontrarHotelMaisBarato(List<string> dias, string tipoParticipante) {

            List<Hotel> hoteis = new List<Hotel>();
            hoteis.Add(new JardimBotanico("Jardim Botanico"));
            hoteis.Add(new MarAtlantico("Mar Atlantico"));
            hoteis.Add(new ParqueDasFlores("Parque das Flores"));   

            var jbTaxa = hoteis.Where(o => o.Tipo == "Jardim Botanico").First().GetTaxa(dias, tipoParticipante);
            var maTaxa = hoteis.Where(o => o.Tipo == "Mar Atlantico").First().GetTaxa(dias, tipoParticipante);
            var pdfTaxa = hoteis.Where(o => o.Tipo == "Parque das Flores").First().GetTaxa(dias, tipoParticipante);

            int[] totalDeTodasTaxas = { jbTaxa, maTaxa, pdfTaxa };

            bool contemDuplicados = totalDeTodasTaxas.Distinct().Count() != totalDeTodasTaxas.Length; 

            int maisBarato = 0;
            //verifica mais barato entre os tres no caso de nao existir items duplicados.
            maisBarato = Math.Min(jbTaxa, Math.Min(maTaxa, pdfTaxa));

            if(!contemDuplicados){               
                foreach(var item in hoteis){
                    if(item.TotalTaxa == maisBarato){
                        Console.WriteLine(item.Tipo);
                    }
                }
            } 
            else {
                List<Hotel> duplicados = new List<Hotel>();
                foreach(var item in hoteis){
                    if(item.TotalTaxa == maisBarato){
                        duplicados.Add(item);
                    }
                }
                var maiorClassificacao = duplicados.OrderByDescending(o => o.Classificacao).FirstOrDefault().Tipo;
                Console.WriteLine(maiorClassificacao);
            }            

            return "";           
        }
    }  
    
}