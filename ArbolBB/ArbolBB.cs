using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolBusBin{
    class ArbolBB{
        private Nodo Raiz {get;set;}

        public ArbolBB() {
            Raiz = null;
        }

        public void Agrega(int valor) {
            //recibe valor
            //en el caso de que no hay Raiz, se crea nodo con este valor
            if (Raiz == null) {
                Raiz = new Nodo(valor);
            } else {
                //sino, si es menor va por la izquierda. Crea nodo si necesita
                //sino, si es mayor va por la derecha. Crea nodo si necesita
                AgregaNodo(Raiz, valor);
            }
            
        }

        private void AgregaNodo(Nodo actual, int valor) {
            //Nodo actual tiene el valor a agregar, es menos o mas
            if (actual.Dato == valor) {
                return;
            } else if (valor < actual.Dato) {
                //sino, si es menor va por la izquierda. Crea nodo si necesita
                if (actual.Izq == null) {
                    actual.Izq = new Nodo(valor);
                    return;
                } else {
                    AgregaNodo(actual.Izq, valor);
                }
            } else {
                //sino, si es mayor va por la derecha. Crea nodo si necesita
                if (actual.Der == null) {
                    actual.Der = new Nodo(valor);
                    return;
                } else {
                    AgregaNodo(actual.Der, valor);
                }
            }

        }


        public void ImprimePre() {
            ImprimePreNodo(Raiz);
            Console.WriteLine();
        }
        private void ImprimePreNodo(Nodo n) {
            if (n != null) {
                Console.Write(n.Dato + ", ");
                ImprimePreNodo(n.Izq);
                ImprimePreNodo(n.Der);
            }
        }
        public void ImprimeIn(){
            ImprimeInNodo(Raiz);
            Console.WriteLine();
        }
        private void ImprimeInNodo(Nodo n){
            if (n != null){
                ImprimeInNodo(n.Izq);
                Console.Write(n.Dato + " ");
                ImprimeInNodo(n.Der);
            }
        }
        public void ImprimePos(){
            ImprimePosNodo(Raiz);
            Console.WriteLine();
        }
        private void ImprimePosNodo(Nodo n){
            if (n != null){
                ImprimePosNodo(n.Izq);
                ImprimePosNodo(n.Der);
                Console.Write(n.Dato + " ");
            }
        }
        public void MayorValor()
        {
            int mayor = EncontrarMayor(Raiz);
            Console.Write("Mayor valor del árbol: " + mayor);
        }
        private int EncontrarMayor(Nodo n)
        {
            if (n == null)
                return int.MinValue;

            int valor = n.Dato;
            int maxDer = EncontrarMayor(n.Der);

            return Math.Max(valor, maxDer);
        }
        public void MostrarCantidadHojas(){
            int cantidad = ContarHojas(Raiz);
            Console.Write("Cantidad de nodos hojas: " + cantidad);
        }
        private int ContarHojas(Nodo n){
            if (n == null){
                return 0;
            }

            if (n.Izq == null && n.Der == null) {
                return 1;
            }
            return ContarHojas(n.Izq) + ContarHojas(n.Der);
        }
    }
}
