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
            string datas = "";
            if (index > 0) {
                tipoParticipante = info.Substring(0, index);
                datas = info.Substring(index + 1);
            }                               
            var listDatas = datas.Split(',').ToList();            
            List<string> dias = new List<string>();
            foreach (var item in listDatas) {
                dias.Add(item.Substring(10));                
            }
            // Console.WriteLine("Tipo cliente informado: {0}, Dia(s) informada(s): {1}", tipoParticipante, dias));    
            // foreach(var item in dias){
            //     Console.WriteLine(item);
            // }     

            EncontrarHotelMaisBarato(dias, tipoParticipante);    
        }

        static void EncontrarHotelMaisBarato(List<string> dias, string tipoParticipante) {
            var taxa1 = JardimBotanico.GetTaxa(dias, tipoParticipante);
            var taxa2 = MarAtlantico.GetTaxa(dias, tipoParticipante);
            var taxa3 = ParqueDasFlores.GetTaxa(dias, tipoParticipante);

            var maisBarato = Math.Min(taxa1, Math.Min(taxa2, taxa3));
        }
    }

    public static class JardimBotanico {
        public static int TotalTaxa { get; set; }
        public static int GetClassificacao() {
            return 4;
        }

        public static int GetTaxa(List<string> tipoTaxa, string tipoParticipante) {

            if (tipoParticipante == "Regular"){
                foreach (var tipo in tipoTaxa){
                    if (tipo == "(mon)" || tipo == "(tues)" || tipo == "(wed)" || tipo == "(thur)" || tipo == "(fri)"){
                        TotalTaxa = TotalTaxa + 160;
                    }
                    else if (tipo == "(sat)" || tipo == "(sun)") {
                        TotalTaxa = TotalTaxa + 60;
                    }
                }
            } 
            else if (tipoParticipante == "Fidelidade"){
                foreach (var tipo in tipoTaxa){
                    if (tipo == "(mon)" || tipo == "(tues)" || tipo == "(wed)" || tipo == "(thur)" || tipo == "(fri)"){
                        TotalTaxa = TotalTaxa + 110;
                    }
                    else if (tipo == "(sat)" || tipo == "(sun)") {
                        TotalTaxa = TotalTaxa + 50;
                    }
                }
            }
            return TotalTaxa;
        }
    }

    public static class MarAtlantico {

        public static int TotalTaxa { get; set; }
        public static int GetClassificacao() {
            return 5;
        }

        public static int GetTaxa(List<string> tipoTaxa, string tipoParticipante) {
            
            if (tipoParticipante == "Regular"){
                foreach (var tipo in tipoTaxa){
                    if (tipo == "(mon)" || tipo == "(tues)" || tipo == "(wed)" || tipo == "(thur)" || tipo == "(fri)"){
                        TotalTaxa = TotalTaxa + 220;
                    }
                    else if (tipo == "(sat)" || tipo == "(sun)") {
                        TotalTaxa = TotalTaxa + 150;
                    }
                }
            } 
            else if (tipoParticipante == "Fidelidade"){
                foreach (var tipo in tipoTaxa){
                    if (tipo == "(mon)" || tipo == "(tues)" || tipo == "(wed)" || tipo == "(thur)" || tipo == "(fri)"){
                        TotalTaxa = TotalTaxa + 100;
                    }
                    else if (tipo == "(sat)" || tipo == "(sun)") {
                        TotalTaxa = TotalTaxa + 40;
                    }
                }
            }
            return TotalTaxa;

        }
    }

    public static class ParqueDasFlores {

        public static int TotalTaxa { get; set; }
        public static int GetClassificacao() {
            return 3;
        }

        public static int GetTaxa(List<string> tipoTaxa, string tipoParticipante) {
            
            if (tipoParticipante == "Regular"){
                foreach (var tipo in tipoTaxa){
                    if (tipo == "(mon)" || tipo == "(tues)" || tipo == "(wed)" || tipo == "(thur)" || tipo == "(fri)"){
                        TotalTaxa = TotalTaxa + 110;
                    }
                    else if (tipo == "(sat)" || tipo == "(sun)") {
                        TotalTaxa = TotalTaxa + 90;
                    }
                }
            } 
            else if (tipoParticipante == "Fidelidade"){
                foreach (var tipo in tipoTaxa){
                    if (tipo == "(mon)" || tipo == "(tues)" || tipo == "(wed)" || tipo == "(thur)" || tipo == "(fri)"){
                        TotalTaxa = TotalTaxa + 80;
                    }
                    else if (tipo == "(sat)" || tipo == "(sun)") {
                        TotalTaxa = TotalTaxa + 80;
                    }
                }
            }
            return TotalTaxa;

        }
    }
    
}