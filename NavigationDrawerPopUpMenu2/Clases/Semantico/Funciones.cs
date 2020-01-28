﻿using NavigationDrawerPopUpMenu2.Clases.Sintactico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NavigationDrawerPopUpMenu2.Clases.Semantico
{
    class Funciones
    {




       static    List<TDS> listaTDS = winLexical.Tabla;//traer la tabla de simbolos del lexico

        Stack<Atributos> pilaSemantica = new Stack<Atributos>();




        public int ntupla = 0;
        public int ntemporal = 0;
        // Cuadruplos cdplo = new Cuadruplos();
        static List<Cuadruplos> CodigoIntermedio = new List<Cuadruplos>();
        List<Produccion> listaReglasReconocidas = winSintactico.ReglaReco1;

        internal static List<Cuadruplos> CodigoIntermedio1 { get => CodigoIntermedio; set => CodigoIntermedio = value; }
        internal static List<TDS> ListaTDS { get => listaTDS; set => listaTDS = value; }

        public Funciones()
        {
        }

        public int Next() {
            ntupla++;
            Cuadruplos cdplo = new Cuadruplos();
            cdplo.numbertupla = ntupla;
            CodigoIntermedio.Add(cdplo);
            return ntupla;
        }

        public string DameTemporal(int tipo)
        {
            ntemporal++;
            string temporal = "T" + ntemporal;
            TDS variable = new TDS();
            variable.nombre = temporal;
            variable.nToken = listaTDS.Count + 1;
            variable.tipo = tipo;

            switch (tipo)
            {
                case 1: variable.size = 4; break;
                case 2: variable.size = 8; break;
                case 3: variable.size = 1; break;
                case 4: variable.size = 80; break;
                case 5: variable.size = 1; break;


            }
            variable.valor = null;
            listaTDS.Add(variable);
            return temporal;



        }


        public void Gen(string operador, string operando1, string operando2, string resultado) {
            CodigoIntermedio[ntupla - 1].operador = operador;
            CodigoIntermedio[ntupla - 1].operando1 = operando1;
            CodigoIntermedio[ntupla - 1].operando2 = operando2;
            CodigoIntermedio[ntupla - 1].resultado = resultado;
            // CodigoIntermedio.Add(cdplo);
        }

        public void GenerarCodigoCuadruplos()
        {
            Atributos atr;
            Atributos atr1;
            Atributos atr2;
            Atributos atr3;
            Atributos atr4;

            for (int i = 0; i < listaReglasReconocidas.Count; i++)
            {
                atr = new Atributos();
                atr1 = new Atributos();
                atr1 = new Atributos();
                atr2 = new Atributos();
                atr3 = new Atributos();
                atr4 = new Atributos();

                int numregla = listaReglasReconocidas[i].n;

                switch (numregla)
                {


                    case 1:
                        break;
                    case 2://D->U : <declarar> -> <undeclare>
                        //atr = pilaSemantica.Pop();
                        //atr.NoTerminal = listaReglasReconocidas[i].ParteIzquierda;
                        //atr.Name = "declarar";
                        //pilaSemantica.Push(atr);
                        break;
                    case 3:
                        //atr = pilaSemantica.Pop();
                        //atr.NoTerminal = listaReglasReconocidas[i].ParteIzquierda;
                        //atr.Name = "declarar";
                        //pilaSemantica.Push(atr);
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 8:
                        break;
                    case 9:
                        break;
                    case 10:
                        break;
                    case 11:
                        // atr.principio = Next();
                        //atr.siguiente = atr.principio + 1;
                        if (!listaReglasReconocidas[i - 1].dato.Equals(";"))
                        {
                            atr.valor = listaReglasReconocidas[i - 1].dato;
                            //compararTipos(atr, atr1);
                            // Gen(":=", atr.valor.ToString(), null, listaReglasReconocidas[i - 1].dato.ToString());
                            atr.noterminal = listaReglasReconocidas[i].izq;
                            atr.name = "listavar";
                            atr.Tipo = atr1.Tipo;
                            //atr.principio = atr1.principio;    /////    ojo aqui posible error
                            pilaSemantica.Push(atr);
                        }
                        else {
                            atr.valor = listaReglasReconocidas[i].dato;
                            //compararTipos(atr, atr1);
                            // Gen(":=", atr.valor.ToString(), null, listaReglasReconocidas[i - 1].dato.ToString());
                            atr.noterminal = listaReglasReconocidas[i+1].izq;
                            atr.name = "listavar";
                            atr.Tipo = atr1.Tipo;
                            //atr.principio = atr1.principio;    /////    ojo aqui posible error
                            pilaSemantica.Push(atr);

                        }
                        break;
                    case 12:

                        atr1 = pilaSemantica.Pop(); //esto es igual a lo que tengo de factor         ///////////errorkdcjsdkcsncknsdkn       
                        atr.principio = Next();
                        atr.siguiente = atr.principio + 1;

                        atr.valor = listaReglasReconocidas[i].dato;
                        //compararTipos(atr, atr1);
                        Gen(":=", atr.valor.ToString(), null, atr1.valor.ToString());
                        atr.noterminal = listaReglasReconocidas[i].izq;
                        atr.name = "inicializa";
                        atr.Tipo = atr1.Tipo;
                        //atr.principio = atr1.principio;    /////    ojo aqui posible error
                        pilaSemantica.Push(atr);

                        break;
                    case 13:
                        break;
                    case 14:
                        break;
                    case 15:
                        break;
                    case 16://I->X : <instrucciones> -> <instrucción>
                        atr = pilaSemantica.Pop();
                        atr.noterminal = listaReglasReconocidas[i].izq;
                        atr.name = "instrucciones";
                        pilaSemantica.Push(atr);
                        break;
                    case 17: // I -> xI : <intruccion> -> <instruccion><instrucciones>
                        atr = new Atributos();
                        atr1 = pilaSemantica.Pop(); // aqui se baja de la pila el valor no terminal I
                        atr2 = pilaSemantica.Pop(); // aqui se baja de la pila el valor no terminal de x
                        atr.principio = atr2.principio;
                        atr.siguiente = atr1.siguiente;
                        atr.noterminal = listaReglasReconocidas[i].izq;
                        atr.name = "instruciones";
                        pilaSemantica.Push(atr);
                        break;
                    case 18://X->Y : <instrucción> -> <if>
                        atr = pilaSemantica.Pop();
                        atr.noterminal = listaReglasReconocidas[i].izq;
                        atr.name = "instrucción";
                        pilaSemantica.Push(atr);
                        break;
                    case 19://X->W : <instrucción> -> <while>
                        atr = pilaSemantica.Pop();
                        atr.noterminal = listaReglasReconocidas[i].izq;
                        atr.name = "instrucción";
                        pilaSemantica.Push(atr);
                        break;
                    case 20://X->S : <instrucción> -> <for>
                        atr = pilaSemantica.Pop();
                        atr.noterminal = listaReglasReconocidas[i].izq;
                        atr.name = "instrucción";
                        pilaSemantica.Push(atr);
                        break;
                    case 21://X->V : <instrucción> -> <escribir>
                        atr = pilaSemantica.Pop();
                        atr.noterminal = listaReglasReconocidas[i].izq;
                        atr.name = "instrucción";
                        pilaSemantica.Push(atr);
                        break;
                    case 22://X->R : <instrucción> -> <leer>
                        atr = pilaSemantica.Pop();
                        atr.noterminal = listaReglasReconocidas[i].izq;
                        atr.name = "instrucción";
                        pilaSemantica.Push(atr);
                        break;
                    case 23://X->O : <instrucción> -> <do>
                        atr = pilaSemantica.Pop();
                        atr.noterminal = listaReglasReconocidas[i].izq;
                        atr.name = "instrucción";
                        pilaSemantica.Push(atr);
                        break;
                    case 24://X->M : <instrucción> -> <incremento>
                        atr = pilaSemantica.Pop();
                        atr.noterminal = listaReglasReconocidas[i].izq;
                        atr.name = "instrucción";
                        pilaSemantica.Push(atr);
                        break;
                    case 25://X->A : <instrucción> -> <asigna>
                        atr = pilaSemantica.Pop();
                        atr.noterminal = listaReglasReconocidas[i].izq;
                        atr.name = "instrucción";
                        pilaSemantica.Push(atr);
                        break;
                    case 26:
                        break;
                    case 27:  // Y --> q (Z){I}Q  :  <if> -> if (<condicion>) {<instruciones>} <else>
                              //  atr = new Atributos();
                        atr3 = pilaSemantica.Pop(); // saco Q
                        atr2 = pilaSemantica.Pop(); // saco I
                        atr1 = pilaSemantica.Pop(); // saco Z
                        atr.principio = atr1.principio;
                        BackPatch(atr2.principio, atr1.verdadero);
                        if (atr3.principio == 0)
                        {
                            atr.siguiente = atr2.siguiente;
                            BackPatch(atr2.siguiente, atr1.falsos);
                        }
                        else
                        {
                            BackPatch(atr3.principio, atr1.falsos);
                            atr.siguiente = atr3.siguiente;
                        }
                        atr.noterminal = listaReglasReconocidas[i].izq;
                        atr.name = "if";
                        pilaSemantica.Push(atr);
                        break;
                    case 28:// Q --> m {I}   :  <else> -> continue {<instrucciones>}
                        atr = pilaSemantica.Pop();
                        atr.noterminal = listaReglasReconocidas[i].izq;
                        atr.name = "else";
                        pilaSemantica.Push(atr);
                        break;
                    case 29: // Q--> vacio : <else> -> vacio
                        atr = new Atributos();
                        atr.noterminal = listaReglasReconocidas[i].izq;
                        atr.name = "else";
                        atr.principio = 0;
                        atr.siguiente = 0;
                        pilaSemantica.Push(atr);
                        break;
                    case 30: // W --> x(Z){I}  : <while>(<condicion>){instrucciones}==============================================================posible error
                        atr = new Atributos();
                        atr1 = pilaSemantica.Pop(); // aqui se baja de la pila el valor no terminal I
                        atr2 = pilaSemantica.Pop(); // aqui se baja de la pila el valor no terminal de Z
                        BackPatch(atr2.siguiente, atr2.verdadero);//aqui cambio atr.principio por atr2.siguiente
                        atr.principio = atr1.principio;
                        atr.siguiente = Next() + 1;
                        Gen(null, null, null, "GoTo: " + atr2.principio + "");
                        BackPatch(atr.siguiente, atr2.falsos);
                        atr.noterminal = listaReglasReconocidas[i].izq;
                        atr.name = "while";
                        pilaSemantica.Push(atr);
                        break;
                    case 31:  //for
                        atr1 = pilaSemantica.Pop(); // aqui saca la regla del incremento noterminal =M
                        atr2 = pilaSemantica.Pop(); // saca la condicion  noterminal= Z
                        atr3 = pilaSemantica.Pop(); // saca instrucciones  noterminal I
                        atr4 = pilaSemantica.Pop();  // saca iN
                        BackPatch(atr1.principio,atr2.verdadero);
                       // BackPatch(atr2.siguiente, atr2.verdadero);//aqui cambio atr.principio por atr2.siguiente
                        atr.principio = atr1.principio;
                        atr.siguiente = Next() + 1;
                        Gen(null, null, null, "GoTo: " + atr4.siguiente + "");
                        BackPatch(atr.siguiente, atr2.falsos);
                        atr.noterminal = listaReglasReconocidas[i].izq;
                        atr.name = "for";
                       // pilaSemantica.Push(atr1);//    posible error de for

                        pilaSemantica.Push(atr);


                        break;
                    case 32:
                       // atr = new Atributos();
                       // atr1 = pilaSemantica.Pop(); //esto es igual a lo que tengo termino T
                        // atr2 = pilaSemantica.Pop();// esto es igual a expresion  E    
                                                     // compararTipos(atr1, atr2);
                        atr.principio = Next();  ///posiblie errorr
                        atr.siguiente = atr.principio + 1;
                        atr.valor = listaReglasReconocidas[i].dato;
                        atr1.valor = DameTemporal(atr1.Tipo);
                        Gen("+", "1", atr.valor.ToString(), atr1.valor.ToString());
                        atr.noterminal = listaReglasReconocidas[i].izq;
                        atr.name = "incremento";
                        atr1.principio = Next();
                        Gen(":=", atr1.valor.ToString(), null, atr.valor.ToString());






                        pilaSemantica.Push(atr);





                        break;
                    case 33:
                        break;
                    case 34:
                        break;
                    case 35:
                        break;
                    case 36:
                        break;
                    case 37:
                        break;
                    case 38:
                        break;
                    case (39)://A->i:E;     : <asigna> -> identificador := <expresión>
                      //  atr = new Atributos();
                        atr1 = pilaSemantica.Pop(); //esto es igual a lo que tengo de factor         ///////////errorkdcjsdkcsncknsdkn       
                        atr.principio = Next();
                        atr.siguiente = atr.principio + 1;
                        atr.valor = listaReglasReconocidas[i].dato;
                        compararTipos(atr, atr1);
                        Gen(":=", atr1.valor.ToString(), null, atr.valor.ToString());
                        atr.noterminal = listaReglasReconocidas[i].izq;
                        atr.name = "asigna";
                        atr.Tipo = atr1.Tipo;
                        //atr.principio = atr1.principio;    /////    ojo aqui posible error
                        pilaSemantica.Push(atr);
                        break;
                    case 40: //Z -> E B E   :  <condicion> -> <expresion><operel><expresion>
                        atr2 = pilaSemantica.Pop();// E1
                        atr3 = pilaSemantica.Pop();// B
                        atr1 = pilaSemantica.Pop();// E2
                        if (atr3.valor.ToString() == "||" || atr3.valor.ToString() == "&&")
                        {
                            if (atr1.principio == 0)
                            {
                                atr1.principio = Next();
                                atr1.verdadero = MakeList(atr1.principio);
                                Gen("if", atr1.valor.ToString(), null, "Goto: ");
                                atr1.siguiente = Next();
                                atr1.falsos = MakeList(atr1.siguiente);
                                Gen(null, null, null, "Goto: ");
                                atr1.siguiente++;
                            }
                            if (atr2.principio == 0)
                            {
                                atr2.principio = Next();
                                atr2.verdadero = MakeList(atr2.principio);
                                Gen("if", atr2.valor.ToString(), null, "Goto: ");
                                atr2.siguiente = Next();
                                atr2.falsos = MakeList(atr2.siguiente);
                                Gen(null, null, null, "Goto: ");
                                atr2.siguiente++;
                            }
                            if (atr3.valor.ToString() == "||")
                            {
                                // generar codigo OR
                                atr.name = "condicion";
                                atr.noterminal = listaReglasReconocidas[i].izq;
                                atr.principio = atr1.principio;
                                atr.siguiente = atr2.siguiente;
                                atr.verdadero = Merge(atr1.verdadero, atr2.verdadero);
                                atr.falsos = atr2.falsos;
                                BackPatch(atr1.siguiente, atr1.falsos);
                                pilaSemantica.Push(atr);
                            }
                            if (atr3.valor.ToString() == "&&")
                            {
                                // Generar codigo AND
                                atr.name = "condicion";
                                atr.noterminal = listaReglasReconocidas[i].izq;
                                atr.principio = atr1.principio;
                                atr.siguiente = atr2.siguiente;
                                atr.verdadero = atr2.verdadero;
                                atr.falsos = Merge(atr1.falsos, atr2.falsos);
                                BackPatch(atr2.principio, atr1.verdadero);
                                pilaSemantica.Push(atr);
                            }
                        }
                        else
                        {
                            // todos los otro operadores
                            atr.name = "condicion";
                            atr.noterminal = listaReglasReconocidas[i].izq;
                            atr.principio = Next();
                            atr.verdadero = MakeList(atr.principio);
                            Gen(atr3.valor.ToString(), atr1.valor.ToString(), atr2.valor.ToString(), "Goto: ");
                            atr.siguiente = Next();
                            atr.falsos = MakeList(atr.siguiente);
                            Gen(null, null, null, "Goto: ");
                            atr.siguiente++;
                            pilaSemantica.Push(atr);
                        }
                        break;
                    case 41: // B -> |  : <operel> -> ||
                        atr = new Atributos();
                        atr.noterminal = listaReglasReconocidas[i].izq;
                        atr.name = "operel";
                        atr.valor = "||";
                        atr.Tipo = 5;
                        pilaSemantica.Push(atr);
                        break;
                    case 42:
                        // B -> &  : <operel> -> &&
                        atr = new Atributos();
                        atr.noterminal = listaReglasReconocidas[i].izq;
                        atr.name = "operel";
                        atr.valor = "&&";
                        atr.Tipo = 5;
                        pilaSemantica.Push(atr);
                        break;
                    case 43:
                        // B -> #  : <operel> -> <>
                        atr = new Atributos();
                        atr.noterminal = listaReglasReconocidas[i].izq;
                        atr.name = "operel";
                        atr.valor = "<>";
                        atr.Tipo = 5;
                        pilaSemantica.Push(atr);
                        break;
                    case 44:
                        // B -> >  : <operel> -> >
                        atr = new Atributos();
                        atr.noterminal = listaReglasReconocidas[i].izq;
                        atr.name = "operel";
                        atr.valor = ">";
                        atr.Tipo = 5;
                        pilaSemantica.Push(atr);
                        break;
                    case 45:
                        // B -> <  : <operel> -> <
                        atr = new Atributos();
                        atr.noterminal = listaReglasReconocidas[i].izq;
                        atr.name = "operel";
                        atr.valor = "<";
                        atr.Tipo = 5;
                        pilaSemantica.Push(atr);
                        break;
                    case 46:
                        // B -> $  : <operel> -> >=
                        atr = new Atributos();
                        atr.noterminal = listaReglasReconocidas[i].izq;
                        atr.name = "operel";
                        atr.valor = ">=";
                        atr.Tipo = 5;
                        pilaSemantica.Push(atr);
                        break;
                    case 47:
                        // B -> %  : <operel> -> <=
                        atr = new Atributos();
                        atr.noterminal = listaReglasReconocidas[i].izq;
                        atr.name = "operel";
                        atr.valor = "<=";
                        atr.Tipo = 5;
                        pilaSemantica.Push(atr);
                        break;
                    case 48:
                        // B -> =  : <operel> -> =
                        atr = new Atributos();
                        atr.noterminal = listaReglasReconocidas[i].izq;
                        atr.name = "operel";
                        atr.valor = "=";
                        atr.Tipo = 5;
                        pilaSemantica.Push(atr);
                        break;
                    case 49://E->E + T : <expresion> -> <expresion> + <termino>
                        atr = new Atributos();
                        atr1 = pilaSemantica.Pop(); //esto es igual a lo que tengo termino T
                        atr2 = pilaSemantica.Pop();// esto es igual a expresion  E    
                        compararTipos(atr1, atr2);
                        atr.principio = Next();  ///posiblie errorr
                        atr.siguiente = atr.principio + 1;
                        if (atr1.principio != 0)
                        {
                            atr.principio = atr1.principio;
                        }
                        atr.valor = DameTemporal(atr1.Tipo);
                        Gen("+", atr1.valor.ToString(), atr2.valor.ToString(), atr.valor.ToString());
                        atr.noterminal = listaReglasReconocidas[i].izq;
                        atr.name = "expresion";
                        pilaSemantica.Push(atr);
                        break;
                    case 50: //E->E - T : <expresion> -> <expresion> - <termino>
                        atr = new Atributos();
                        atr1 = pilaSemantica.Pop(); //esto es igual a lo que tengo termino T
                        atr2 = pilaSemantica.Pop();// esto es igual a expresion  E    
                        compararTipos(atr1, atr2);
                        atr.principio = Next();
                        atr.siguiente = atr.principio + 1;
                        if (atr1.principio != 0)
                        {
                            atr.principio = atr1.principio;
                        }
                        atr.valor = DameTemporal(atr1.Tipo);
                        Gen("-", atr1.valor.ToString(), atr2.valor.ToString(), atr.valor.ToString());
                        atr.noterminal = listaReglasReconocidas[i].izq;
                        atr.name = "expresion";
                        pilaSemantica.Push(atr);
                        break;
                    case 51://E->T : <expresion> -> <termino>
                        atr = pilaSemantica.Pop();
                        atr.noterminal = listaReglasReconocidas[i].izq;
                        atr.name = "expresion";
                        pilaSemantica.Push(atr);
                        break;
                    case 52://T->T*F : <termino> -> <termino> * <factor>======================================ddddddd========error
                        atr = new Atributos();
                        atr1 = pilaSemantica.Pop(); //esto es igual a lo que tengo de F
                        atr2 = pilaSemantica.Pop();// esto es igual a termino T                 
                        compararTipos(atr1, atr2);
                        atr.principio = Next();
                        atr.siguiente = atr.principio + 1;
                        if (atr1.principio != 0)
                        {
                            atr.principio = atr1.principio;
                        }
                        atr.valor = DameTemporal(atr1.Tipo);
                        Gen("*", atr1.valor.ToString(), atr2.valor.ToString(), atr.valor.ToString());
                        atr.noterminal = listaReglasReconocidas[i].izq;
                        atr.name = "termino";
                        pilaSemantica.Push(atr);
                        break;
                    case 53://T->T/F : <termino> -> <termino> / <factor>
                       // atr = new Atributos();
                        atr1 = pilaSemantica.Pop(); //esto es igual a lo que tengo de F
                        atr2 = pilaSemantica.Pop();// esto es igual a termino T                         
                        compararTipos(atr1, atr2);
                        atr.principio = Next();
                        atr.siguiente = atr.principio + 1;
                        if (atr1.principio != 0)
                        {
                            atr.principio = atr1.principio;
                        }
                        atr.valor = DameTemporal(atr1.Tipo);
                        Gen("/", atr1.valor.ToString(), atr2.valor.ToString(), atr.valor.ToString());
                        atr.noterminal = listaReglasReconocidas[i].izq;
                        atr.name = "termino";
                        pilaSemantica.Push(atr);
                        break;
                    case 54://T->T^F : <termino> -> <termino> ^ <factor>
                        atr = new Atributos();
                        atr1 = pilaSemantica.Pop(); //esto es igual a lo que tengo de F
                        atr2 = pilaSemantica.Pop();// esto es igual a termino T                       
                        compararTipos(atr1, atr2);
                        atr.principio = Next();
                        atr.siguiente = atr.principio + 1;
                        if (atr1.principio != 0)
                        {
                            atr.principio = atr1.principio;
                        }
                        atr.valor = DameTemporal(atr1.Tipo);
                        Gen("^", atr1.valor.ToString(), atr2.valor.ToString(), atr.valor.ToString());
                        atr.noterminal = listaReglasReconocidas[i].izq;
                        atr.name = "termino";
                        pilaSemantica.Push(atr);
                        break;
                    case 55://T->F : <termino> -> <factor>
                        atr = pilaSemantica.Pop();
                        atr.noterminal = listaReglasReconocidas[i].izq;
                        atr.name = "termino";
                        pilaSemantica.Push(atr);
                        break;
                    case 56://F->i : <factor> -> identificador
                        atr = new Atributos();
                        atr.noterminal = listaReglasReconocidas[i].izq;
                        atr.name = "factor";
                        atr.valor = listaReglasReconocidas[i].dato;
                         atr.Tipo = buscartipoTDS(atr.valor.ToString());
                        pilaSemantica.Push(atr);
                        break;
                    case 57://F->(E) : <factor> -> <expresion>
                        atr = pilaSemantica.Pop();
                        atr.noterminal = listaReglasReconocidas[i].izq;
                        atr.name = "factor";
                        pilaSemantica.Push(atr);
                        break;
                    case 58://F->a : <factor> -> literal
                        atr = new Atributos();
                        atr.noterminal = listaReglasReconocidas[i].izq;
                        atr.name = "factor";
                        atr.valor = listaReglasReconocidas[i].dato;
                        if (listaReglasReconocidas[i].Tipo == "literalentero")
                        {
                            atr.Tipo = 1;
                        }
                        else if (listaReglasReconocidas[i].Tipo == "literalreal")
                        {
                            atr.Tipo = 2;
                        }
                        else if (listaReglasReconocidas[i].Tipo == "literalcadena")
                        {
                            atr.Tipo = 4;
                        }
                        else if (listaReglasReconocidas[i].Tipo == "literalchar")
                        {
                            atr.Tipo = 3;
                        }
                        pilaSemantica.Push(atr);
                        break;
                    case 59://F->v : <factor> -> true
                        atr = new Atributos();
                        atr.noterminal = listaReglasReconocidas[i].izq;
                        atr.name = "factor";
                        atr.valor = true;
                        atr.Tipo = 5;
                        pilaSemantica.Push(atr);
                        break;
                    case 60://F->f : <factor> -> falso
                        atr = new Atributos();
                        atr.noterminal = listaReglasReconocidas[i].izq;
                        atr.name = "factor";
                        atr.valor = false;
                        atr.Tipo = 5;
                        pilaSemantica.Push(atr);
                        break;
                }
            }
        }




        void BackPatch(int dir, List<int> lista)
        {
            foreach (int v in lista)
            {
                if (dir == 12) {
                 String resultado=   CodigoIntermedio[v - 1].resultado;
                   
                }

                    CodigoIntermedio[v - 1].resultado = "Goto: " + dir.ToString();
                
            }
        }

        public List<int> MakeList(int valor) {
            List<int> tList = new List<int>();
            tList.Add(valor);
            return (tList);
        }
        public List<int> Merge(List<int> l1, List<int> l2) {
            List<int> lr = new List<int>();
            foreach (var v in l1) {
                lr.Add(v);


            }
            foreach (var u in l2)
            {
                lr.Add(u);


            }
            return lr;
        }

        public int buscartipoTDS(string valor)
        {
            for (int i = 0; i < listaTDS.Count; i++)
            {
                if (listaTDS[i].nombre == valor)
                {
                    return listaTDS[i].tipo;
                }
            }
            return 0;
        }

       
            public void compararTipos(Atributos atr1, Atributos atr2)
            {
                int t1, t2;
                if (atr1.Tipo == 0) // los dos son identificadores
                {
                    t1 = buscartipoTDS(atr1.valor.ToString());
                    atr1.Tipo = t1;
                }
                else
                {
                    t1 = atr1.Tipo;

                }
                if (atr2.Tipo == 0)
                {
                    t2 = buscartipoTDS(atr2.valor.ToString());
                    atr2.Tipo = t2;
                }
                else
                {
                    t2 = atr2.Tipo;
                }
                if (t1 > 2 || t2 > 2)
                {
                    MessageBox.Show("ERROR: no se puede realizar operaciones con char, string o bool");
                }
                else
                {
                    if (t1 != t2)
                    {
                        MessageBox.Show("ERROR TIPOS NO COMPATIBLES!!");
                        //mensaje de error tipos no compatibles                       
                    }
                }
            }
        
    }
}
