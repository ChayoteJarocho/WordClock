using System.Collections.Generic;

namespace WordClock
{
    /**
        e s o n m e d i a n o c h e l a s
        u n a d o s t r e s e i s i e t e
        c u a t r o c i n c o c h o n c e
        n u e v e d i e z d o c e c u a r t o
        d e l p a r a d i a l a s m a ñ a n a
        t a r d e n o c h e m a d r u g a d a
        c o n y v e i n t e t r e i n t a
        c u a r e n t a d i e c i y v e i n t i
        u n a d o s t r e s e i s i e t e
        c u a t r o c i n c o c h o n c e
        n u e v e d i e z d o c e c u a r t o
        t r e c e d e l c a t o r c e l a
        m i n u t o s m a ñ a n a t a r d e
        m e d i a n o c h e m a d r u g a d a 
    */
    public class ClockSpanish : Clock
    {
        public ClockSpanish() : base()
        {
            Lines.Add(EsSonMediaNocheLas);
            Lines.Add(UnaDosTresSeisSiete1);
            Lines.Add(CuatroCincoOchoOnce1);
            Lines.Add(NueveDiezDoceCuarto1);
            Lines.Add(DelParaLasDiaManana);
            Lines.Add(TardeNocheMadrugada);
            Lines.Add(ConYVeinteTreinta);
            Lines.Add(CuarentaDieciYVeinti);
            Lines.Add(UnaDosTresSeisSiete2);
            Lines.Add(CuatroCincoOchoOnce2);
            Lines.Add(NueveDiezDoceCuarto2);
            Lines.Add(TreceDeCatorceLa);
            Lines.Add(MinutosMananaTarde);
            Lines.Add(MediaNocheMadrugada);
        }

        private bool Dieci => M >= 16 && M <= 19;
        private bool Decenas => M >= 10 && M <= 19;
        private bool Veintes => M >= 20 && M <= 29;
        private bool Treintas => M >= 30 && M <= 39;
        private bool Cuarentas => M >= 40 && M <= 49;
        private bool Cincuentas => M >= 50 && M <= 59;

        /// <summary>
        /// 0 &lt; H &lt;= 6
        /// </summary>
        private bool Madrugada => H >= 0 && H <= 6;

        /// <summary>
        /// 7 &gt;= H &lt;= 11
        /// </summary>
        private bool Manana => H >= 7 && H <= 11;
        private bool Mediodia => H == 12;
        private bool MediodiaEnPunto => Mediodia && M == 0;
        private bool Tarde => H >= 13 && H <= 18;
        private bool Noche => H >= 19 && H <= 23;
        private bool Medianoche => H == 0;
        private bool MedianocheEnPunto => Medianoche && M == 0;

        private bool LasXYCuarto => M == 15;
        private bool CuartoParaLasX => M == 45;
        private bool CuartoODiezParaLasX => CuartoParaLasX || Cincuentas;
        private bool ParaLasXDeLaMadrugada => H >= 0 && H <= 5;
        private bool ParaLasXDeLaManana => H >= 6 && H <= 10;
        private bool ParaLasXDelMediodia => H == 11;
        private bool ParaLasXDeLaTarde => H >= 12 && H <= 17;
        private bool ParaLasXDeLaNoche => (H >= 18 && H <= 22);
        private bool ParaLaMediaNoche => H == 23;

        private Line EsSonMediaNocheLas => new(new List<Letter>
            {
                new('e', () => (H1 && !CuartoODiezParaLasX) || MedianocheEnPunto || (CuartoODiezParaLasX && M == 59)),
                new('s', () => true),
                new('o', () => MediodiaEnPunto || ((CuartoODiezParaLasX || (!H1 && !MedianocheEnPunto && !MediodiaEnPunto)) && M != 59)),
                new('n', () => MediodiaEnPunto || ((CuartoODiezParaLasX || (!H1 && !MedianocheEnPunto && !MediodiaEnPunto)) && M != 59)),
                new('m', () => MedianocheEnPunto),
                new('e', () => MedianocheEnPunto),
                new('d', () => MedianocheEnPunto),
                new('i', () => MedianocheEnPunto),
                new('a', () => MedianocheEnPunto),
                new('n', () => MedianocheEnPunto),
                new('o', () => MedianocheEnPunto),
                new('c', () => MedianocheEnPunto),
                new('h', () => MedianocheEnPunto),
                new('e', () => MedianocheEnPunto),
                new('l', () => !MedianocheEnPunto && !CuartoODiezParaLasX),
                new('a', () => !MedianocheEnPunto && !CuartoODiezParaLasX),
                new('s', () => !MedianocheEnPunto && !H1 && !CuartoODiezParaLasX)
            });

        private Line UnaDosTresSeisSiete1 => new(new List<Letter>
            {
                new('u', () => (H1 && !CuartoODiezParaLasX) || M == 59),
                new('n', () => (H1 && !CuartoODiezParaLasX) || M == 59),
                new('a', () => (H1 && !CuartoODiezParaLasX) || M == 59),
                new('d', () => (H2 && !CuartoODiezParaLasX) || M == 58),
                new('o', () => (H2 && !CuartoODiezParaLasX) || M == 58),
                new('s', () => (H2 && !CuartoODiezParaLasX) || M == 58),
                new('t', () => (H3 && !CuartoODiezParaLasX) || M == 57),
                new('r', () => (H3 && !CuartoODiezParaLasX) || M == 57),
                new('e', () => (H3 && !CuartoODiezParaLasX) || M == 57),
                new('s', () => ((H3 || H6) && !CuartoODiezParaLasX) || M == 57 || M == 54),
                new('e', () => (H6 && !CuartoODiezParaLasX) || M == 54),
                new('i', () => (H6 && !CuartoODiezParaLasX) || M == 54),
                new('s', () => ((H6 || H7) && !CuartoODiezParaLasX) || M == 54 || M == 53),
                new('i', () => (H7 && !CuartoODiezParaLasX) || M == 53),
                new('e', () => (H7 && !CuartoODiezParaLasX) || M == 53),
                new('t', () => (H7 && !CuartoODiezParaLasX) || M == 53),
                new('e', () => (H7 && !CuartoODiezParaLasX) || M == 53)
            });

        private Line CuatroCincoOchoOnce1 => new(new List<Letter>
            {
                new('c', () => ((H4 && !CuartoODiezParaLasX) || M == 56)),
                new('u', () => ((H4 && !CuartoODiezParaLasX) || M == 56)),
                new('a', () => ((H4 && !CuartoODiezParaLasX) || M == 56)),
                new('t', () => ((H4 && !CuartoODiezParaLasX) || M == 56)),
                new('r', () => ((H4 && !CuartoODiezParaLasX) || M == 56)),
                new('o', () => ((H4 && !CuartoODiezParaLasX) || M == 56)),
                new('c', () => ((H5 && !CuartoODiezParaLasX) || M == 55)),
                new('i', () => ((H5 && !CuartoODiezParaLasX) || M == 55)),
                new('n', () => ((H5 && !CuartoODiezParaLasX) || M == 55)),
                new('c', () => ((H5 && !CuartoODiezParaLasX) || M == 55)),
                new('o', () => (((H5 || H8) && !CuartoODiezParaLasX) || M == 55 || M == 52)),
                new('c', () => ((H8 && !CuartoODiezParaLasX) || M == 52)),
                new('h', () => ((H8 && !CuartoODiezParaLasX) || M == 52)),
                new('o', () => (((H8 || H11) && !CuartoODiezParaLasX) || M == 52)),
                new('n', () => H11 && !CuartoODiezParaLasX),
                new('c', () => H11 && !CuartoODiezParaLasX),
                new('e', () => H11 && !CuartoODiezParaLasX)
            });

        private Line NueveDiezDoceCuarto1 => new(new List<Letter>
            {
                new('n', () => ((H9 && !CuartoODiezParaLasX) || M == 51)),
                new('u', () => ((H9 && !CuartoODiezParaLasX) || M == 51)),
                new('e', () => ((H9 && !CuartoODiezParaLasX) || M == 51)),
                new('v', () => ((H9 && !CuartoODiezParaLasX) || M == 51)),
                new('e', () => ((H9 && !CuartoODiezParaLasX) || M == 51)),
                new('d', () => ((H10 && !CuartoODiezParaLasX) || M == 50)),
                new('i', () => ((H10 && !CuartoODiezParaLasX) || M == 50)),
                new('e', () => ((H10 && !CuartoODiezParaLasX) || M == 50)),
                new('z', () => ((H10 && !CuartoODiezParaLasX) || M == 50)),
                new('d', () => !MedianocheEnPunto && H12 && !CuartoODiezParaLasX),
                new('o', () => !MedianocheEnPunto && H12 && !CuartoODiezParaLasX),
                new('c', () => !MedianocheEnPunto && H12 && !CuartoODiezParaLasX),
                new('e', () => !MedianocheEnPunto && H12 && !CuartoODiezParaLasX),
                new('c', () => CuartoParaLasX),
                new('u', () => CuartoParaLasX),
                new('a', () => CuartoParaLasX),
                new('r', () => CuartoParaLasX),
                new('t', () => CuartoParaLasX),
                new('o', () => CuartoParaLasX)
            });

        private Line DelParaLasDiaManana => new(new List<Letter>
            {
                new('d', () => !MedianocheEnPunto && !CuartoODiezParaLasX && !LasXYCuarto),
                new('e', () => !MedianocheEnPunto && !CuartoODiezParaLasX && !LasXYCuarto),
                new('l', () => !CuartoODiezParaLasX && !LasXYCuarto && MediodiaEnPunto),
                new('p', () => CuartoODiezParaLasX),
                new('a', () => CuartoODiezParaLasX),
                new('r', () => CuartoODiezParaLasX),
                new('a', () => CuartoODiezParaLasX),
                new('d', () => MediodiaEnPunto || Mediodia),
                new('i', () => MediodiaEnPunto || Mediodia),
                new('a', () => MediodiaEnPunto || Mediodia),
                new('l', () => !MedianocheEnPunto && !MediodiaEnPunto && !LasXYCuarto && !Mediodia),
                new('a', () => !MedianocheEnPunto && !MediodiaEnPunto && !LasXYCuarto && !Mediodia),
                new('s', () => CuartoODiezParaLasX && !Mediodia),
                new('m', () => !CuartoODiezParaLasX && !LasXYCuarto && Manana),
                new('a', () => !CuartoODiezParaLasX && !LasXYCuarto && Manana),
                new('ñ', () => !CuartoODiezParaLasX && !LasXYCuarto && Manana),
                new('a', () => !CuartoODiezParaLasX && !LasXYCuarto && Manana),
                new('n', () => !CuartoODiezParaLasX && !LasXYCuarto && Manana),
                new('a', () => !CuartoODiezParaLasX && !LasXYCuarto && Manana)
            });

        private Line TardeNocheMadrugada => new(new List<Letter>
            {
                new('t', () => !CuartoODiezParaLasX && !LasXYCuarto && Tarde),
                new('a', () => !CuartoODiezParaLasX && !LasXYCuarto && Tarde),
                new('r', () => !CuartoODiezParaLasX && !LasXYCuarto && Tarde),
                new('d', () => !CuartoODiezParaLasX && !LasXYCuarto && Tarde),
                new('e', () => !CuartoODiezParaLasX && !LasXYCuarto && Tarde),
                new('n', () => !CuartoODiezParaLasX && !LasXYCuarto && !MedianocheEnPunto && Noche),
                new('o', () => !CuartoODiezParaLasX && !LasXYCuarto && !MedianocheEnPunto && Noche),
                new('c', () => !CuartoODiezParaLasX && !LasXYCuarto && !MedianocheEnPunto && Noche),
                new('h', () => !CuartoODiezParaLasX && !LasXYCuarto && !MedianocheEnPunto && Noche),
                new('e', () => !CuartoODiezParaLasX && !LasXYCuarto && !MedianocheEnPunto && Noche),
                new('m', () => !CuartoODiezParaLasX && !LasXYCuarto && !MedianocheEnPunto && Madrugada),
                new('a', () => !CuartoODiezParaLasX && !LasXYCuarto && !MedianocheEnPunto && Madrugada),
                new('d', () => !CuartoODiezParaLasX && !LasXYCuarto && !MedianocheEnPunto && Madrugada),
                new('r', () => !CuartoODiezParaLasX && !LasXYCuarto && !MedianocheEnPunto && Madrugada),
                new('u', () => !CuartoODiezParaLasX && !LasXYCuarto && !MedianocheEnPunto && Madrugada),
                new('g', () => !CuartoODiezParaLasX && !LasXYCuarto && !MedianocheEnPunto && Madrugada),
                new('a', () => !CuartoODiezParaLasX && !LasXYCuarto && !MedianocheEnPunto && Madrugada),
                new('d', () => !CuartoODiezParaLasX && !LasXYCuarto && !MedianocheEnPunto && Madrugada),
                new('a', () => !CuartoODiezParaLasX && !LasXYCuarto && !MedianocheEnPunto && Madrugada)
            });

        private Line ConYVeinteTreinta => new(new List<Letter>
            {
                new('c', () => !CuartoODiezParaLasX && !LasXYCuarto && M != 0),
                new('o', () => !CuartoODiezParaLasX && !LasXYCuarto && M != 0),
                new('n', () => !CuartoODiezParaLasX && !LasXYCuarto && M != 0),
                new('y', () => LasXYCuarto),
                new('v', () => M == 20),
                new('e', () => M == 20),
                new('i', () => M == 20),
                new('n', () => M == 20),
                new('t', () => M == 20),
                new('e', () => M == 20),
                new('t', () => Treintas),
                new('r', () => Treintas),
                new('e', () => Treintas),
                new('i', () => Treintas),
                new('n', () => Treintas),
                new('t', () => Treintas),
                new('a', () => Treintas)
            });

        private Line CuarentaDieciYVeinti => new(new List<Letter>
            {
                new('c', () => Cuarentas && !CuartoParaLasX),
                new('u', () => Cuarentas && !CuartoParaLasX),
                new('a', () => Cuarentas && !CuartoParaLasX),
                new('r', () => Cuarentas && !CuartoParaLasX),
                new('e', () => Cuarentas && !CuartoParaLasX),
                new('n', () => Cuarentas && !CuartoParaLasX),
                new('t', () => Cuarentas && !CuartoParaLasX),
                new('a', () => Cuarentas && !CuartoParaLasX),
                new('d', () => Dieci),
                new('i', () => Dieci),
                new('e', () => Dieci),
                new('c', () => Dieci),
                new('i', () => Dieci),
                new('y', () => ((Treintas || Cuarentas) && M % 10 != 0) && !CuartoParaLasX),
                new('v', () => Veintes && M != 20),
                new('e', () => Veintes && M != 20),
                new('i', () => Veintes && M != 20),
                new('n', () => Veintes && M != 20),
                new('t', () => Veintes && M != 20),
                new('i', () => Veintes && M != 20)
            });

        private Line UnaDosTresSeisSiete2 => new(new List<Letter>
            {
                new('u', () => CuartoODiezParaLasX && H12 || (!CuartoODiezParaLasX && !Decenas && (M % 10) == 1)),
                new('n', () => CuartoODiezParaLasX && H12 || (!CuartoODiezParaLasX && !Decenas && (M % 10) == 1)),
                new('a', () => CuartoODiezParaLasX && H12),
                new('d', () => CuartoODiezParaLasX && H1 || (!CuartoODiezParaLasX && !Decenas && (M % 10) == 2)),
                new('o', () => CuartoODiezParaLasX && H1 || (!CuartoODiezParaLasX && !Decenas && (M % 10) == 2)),
                new('s', () => CuartoODiezParaLasX && H1 || (!CuartoODiezParaLasX && !Decenas && (M % 10) == 2)),
                new('t', () => CuartoODiezParaLasX && H2 || (!CuartoODiezParaLasX && !Decenas && (M % 10) == 3)),
                new('r', () => CuartoODiezParaLasX && H2 || (!CuartoODiezParaLasX && !Decenas && (M % 10) == 3)),
                new('e', () => CuartoODiezParaLasX && H2 || (!CuartoODiezParaLasX && !Decenas && (M % 10) == 3)),
                new('s', () => (CuartoODiezParaLasX && (H2 || H5)) || (!CuartoODiezParaLasX && (((M % 10) == 3 && !Decenas) || (M % 10) == 6))),
                new('e', () => CuartoODiezParaLasX && H5 || (!CuartoODiezParaLasX && (M % 10) == 6)),
                new('i', () => CuartoODiezParaLasX && H5 || (!CuartoODiezParaLasX && (M % 10) == 6)),
                new('s', () => (CuartoODiezParaLasX && (H5 || H6)) || (!CuartoODiezParaLasX && ((M % 10) == 6 || (M % 10) == 7))),
                new('i', () => CuartoODiezParaLasX && H6 || (!CuartoODiezParaLasX && (M % 10) == 7)),
                new('e', () => CuartoODiezParaLasX && H6 || (!CuartoODiezParaLasX && (M % 10) == 7)),
                new('t', () => CuartoODiezParaLasX && H6 || (!CuartoODiezParaLasX && (M % 10) == 7)),
                new('e', () => CuartoODiezParaLasX && H6 || (!CuartoODiezParaLasX && (M % 10) == 7))
            });

        private Line CuatroCincoOchoOnce2 => new(new List<Letter>
            {
                new('c', () => CuartoODiezParaLasX && H3 || (!CuartoODiezParaLasX && !Decenas && (M % 10) == 4)),
                new('u', () => CuartoODiezParaLasX && H3 || (!CuartoODiezParaLasX && !Decenas && (M % 10) == 4)),
                new('a', () => CuartoODiezParaLasX && H3 || (!CuartoODiezParaLasX && !Decenas && (M % 10) == 4)),
                new('t', () => CuartoODiezParaLasX && H3 || (!CuartoODiezParaLasX && !Decenas && (M % 10) == 4)),
                new('r', () => CuartoODiezParaLasX && H3 || (!CuartoODiezParaLasX && !Decenas && (M % 10) == 4)),
                new('o', () => CuartoODiezParaLasX && H3 || (!CuartoODiezParaLasX && !Decenas && (M % 10) == 4)),
                new('c', () => CuartoODiezParaLasX && H4 || (!CuartoODiezParaLasX && !Decenas && (M % 10) == 5)),
                new('i', () => CuartoODiezParaLasX && H4 || (!CuartoODiezParaLasX && !Decenas && (M % 10) == 5)),
                new('n', () => CuartoODiezParaLasX && H4 || (!CuartoODiezParaLasX && !Decenas && (M % 10) == 5)),
                new('c', () => CuartoODiezParaLasX && H4 || (!CuartoODiezParaLasX && !Decenas && (M % 10) == 5)),
                new('o', () => (CuartoODiezParaLasX && (H4 || H7)) || (!CuartoODiezParaLasX && (((M % 10) == 5 && !Decenas) || (M % 10) == 8))),
                new('c', () => CuartoODiezParaLasX && H7 || (!CuartoODiezParaLasX && (M % 10) == 8)),
                new('h', () => CuartoODiezParaLasX && H7 || (!CuartoODiezParaLasX && (M % 10) == 8)),
                new('o', () => (CuartoODiezParaLasX && H7 || (!CuartoODiezParaLasX && (M % 10) == 8)) || M == 11),
                new('n', () => M == 11),
                new('c', () => M == 11),
                new('e', () => M == 11)
            });

        private Line NueveDiezDoceCuarto2 => new(new List<Letter>
            {
                new('n', () => CuartoODiezParaLasX && H8 || (!CuartoODiezParaLasX && (M % 10) == 9)),
                new('u', () => CuartoODiezParaLasX && H8 || (!CuartoODiezParaLasX && (M % 10) == 9)),
                new('e', () => CuartoODiezParaLasX && H8 || (!CuartoODiezParaLasX && (M % 10) == 9)),
                new('v', () => CuartoODiezParaLasX && H8 || (!CuartoODiezParaLasX && (M % 10) == 9)),
                new('e', () => CuartoODiezParaLasX && H8 || (!CuartoODiezParaLasX && (M % 10) == 9)),
                new('d', () => M == 10),
                new('i', () => M == 10),
                new('e', () => M == 10),
                new('z', () => M == 10),
                new('d', () => M == 12),
                new('o', () => M == 12),
                new('c', () => M == 12),
                new('e', () => M == 12),
                new('c', () => LasXYCuarto),
                new('u', () => LasXYCuarto),
                new('a', () => LasXYCuarto),
                new('r', () => LasXYCuarto),
                new('t', () => LasXYCuarto),
                new('o', () => LasXYCuarto)
            });

        private Line TreceDeCatorceLa => new(new List<Letter>
            {
                new('t', () => M == 13),
                new('r', () => M == 13),
                new('e', () => M == 13),
                new('c', () => M == 13),
                new('e', () => M == 13),
                new('d', () => CuartoODiezParaLasX || LasXYCuarto),
                new('e', () => CuartoODiezParaLasX || LasXYCuarto),
                new('l', () => (CuartoODiezParaLasX || LasXYCuarto) && H == 11),
                new('c', () => M == 14),
                new('a', () => M == 14),
                new('t', () => M == 14),
                new('o', () => M == 14),
                new('r', () => M == 14),
                new('c', () => M == 14),
                new('e', () => M == 14),
                new('l', () => CuartoODiezParaLasX || LasXYCuarto),
                new('a', () => CuartoODiezParaLasX || LasXYCuarto)
            });

        private Line MinutosMananaTarde => new(new List<Letter>
            {
                new('m', () => M != 0 && !LasXYCuarto && !CuartoODiezParaLasX),
                new('i', () => M != 0 && !LasXYCuarto && !CuartoODiezParaLasX),
                new('n', () => M != 0 && !LasXYCuarto && !CuartoODiezParaLasX),
                new('u', () => M != 0 && !LasXYCuarto && !CuartoODiezParaLasX),
                new('t', () => M != 0 && !LasXYCuarto && !CuartoODiezParaLasX),
                new('o', () => M != 0 && !LasXYCuarto && !CuartoODiezParaLasX),
                new('s', () => M != 0 && M != 1 && !LasXYCuarto && !CuartoODiezParaLasX),
                new('m', () => (CuartoODiezParaLasX || LasXYCuarto) && ParaLasXDeLaManana),
                new('a', () => (CuartoODiezParaLasX || LasXYCuarto) && ParaLasXDeLaManana),
                new('ñ', () => (CuartoODiezParaLasX || LasXYCuarto) && ParaLasXDeLaManana),
                new('a', () => (CuartoODiezParaLasX || LasXYCuarto) && ParaLasXDeLaManana),
                new('n', () => (CuartoODiezParaLasX || LasXYCuarto) && ParaLasXDeLaManana),
                new('a', () => (CuartoODiezParaLasX || LasXYCuarto) && ParaLasXDeLaManana),
                new('t', () => (CuartoODiezParaLasX || LasXYCuarto) && ParaLasXDeLaTarde),
                new('a', () => (CuartoODiezParaLasX || LasXYCuarto) && ParaLasXDeLaTarde),
                new('r', () => (CuartoODiezParaLasX || LasXYCuarto) && ParaLasXDeLaTarde),
                new('d', () => (CuartoODiezParaLasX || LasXYCuarto) && ParaLasXDeLaTarde),
                new('e', () => (CuartoODiezParaLasX || LasXYCuarto) && ParaLasXDeLaTarde)
            });

        private Line MediaNocheMadrugada => new(new List<Letter>
            {
                new('m', () => (CuartoODiezParaLasX && ParaLaMediaNoche) || (LasXYCuarto && Medianoche)),
                new('e', () => (CuartoODiezParaLasX && ParaLaMediaNoche) || (LasXYCuarto && Medianoche)),
                new('d', () => (CuartoODiezParaLasX && (ParaLaMediaNoche || ParaLasXDelMediodia)) || (LasXYCuarto && (Medianoche || Mediodia))),
                new('i', () => (CuartoODiezParaLasX && (ParaLaMediaNoche || ParaLasXDelMediodia)) || (LasXYCuarto && (Medianoche || Mediodia))),
                new('a', () => (CuartoODiezParaLasX && (ParaLaMediaNoche || ParaLasXDelMediodia)) || (LasXYCuarto && (Medianoche || Mediodia))),
                new('n', () => (CuartoODiezParaLasX && (ParaLaMediaNoche || ParaLasXDeLaNoche)) || (LasXYCuarto && (Medianoche || Noche))),
                new('o', () => (CuartoODiezParaLasX && (ParaLaMediaNoche || ParaLasXDeLaNoche)) || (LasXYCuarto && (Medianoche || Noche))),
                new('c', () => (CuartoODiezParaLasX && (ParaLaMediaNoche || ParaLasXDeLaNoche)) || (LasXYCuarto && (Medianoche || Noche))),
                new('h', () => (CuartoODiezParaLasX && (ParaLaMediaNoche || ParaLasXDeLaNoche)) || (LasXYCuarto && (Medianoche || Noche))),
                new('e', () => (CuartoODiezParaLasX && (ParaLaMediaNoche || ParaLasXDeLaNoche)) || (LasXYCuarto && (Medianoche || Noche))),
                new('m', () => (CuartoODiezParaLasX && ParaLasXDeLaMadrugada) || (LasXYCuarto && Madrugada && !Medianoche)),
                new('a', () => (CuartoODiezParaLasX && ParaLasXDeLaMadrugada) || (LasXYCuarto && Madrugada && !Medianoche)),
                new('d', () => (CuartoODiezParaLasX && ParaLasXDeLaMadrugada) || (LasXYCuarto && Madrugada && !Medianoche)),
                new('r', () => (CuartoODiezParaLasX && ParaLasXDeLaMadrugada) || (LasXYCuarto && Madrugada && !Medianoche)),
                new('u', () => (CuartoODiezParaLasX && ParaLasXDeLaMadrugada) || (LasXYCuarto && Madrugada && !Medianoche)),
                new('g', () => (CuartoODiezParaLasX && ParaLasXDeLaMadrugada) || (LasXYCuarto && Madrugada && !Medianoche)),
                new('a', () => (CuartoODiezParaLasX && ParaLasXDeLaMadrugada) || (LasXYCuarto && Madrugada && !Medianoche)),
                new('d', () => (CuartoODiezParaLasX && ParaLasXDeLaMadrugada) || (LasXYCuarto && Madrugada && !Medianoche)),
                new('a', () => (CuartoODiezParaLasX && ParaLasXDeLaMadrugada) || (LasXYCuarto && Madrugada && !Medianoche))
            });
    }
}
