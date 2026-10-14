using Futarelszamolas;
List<Futar> Lista = new List<Futar>();
Console.WriteLine("Adatok beolvasása a futarok.txt fájlból...");
foreach (string beolvasott in File.ReadAllLines("futarok.txt"))
{
    Futar aktualis = new Futar();
    string[] adatok=beolvasott.Split(";");
    aktualis.Nev=adatok[0];
    aktualis.MegtettKm = int.Parse(adatok[1]);
    aktualis.Csomagszam = int.Parse(adatok[2]);
    aktualis.KesesPercek = int.Parse(adatok[3]);
    Lista.Add( aktualis );
}


int teljesber = 0;
int osszcsomag = 0;
int legmagasabbber = 0;
string legjobbdolgozo = "";
int nincskeses = 0;
for (int i = 0; i < Lista.Count; i++)
{
    int bonusz = 0;
    int levonas = 0;
    if (Lista[i].Csomagszam>=20 && Lista[i].KesesPercek < 15) { bonusz = 8000;}
    if (Lista[i].KesesPercek >= 30) { levonas = 5000; }
    Console.WriteLine($"{Lista[i].Nev}: {Lista[i].Csomagszam} csomag, {Lista[i].MegtettKm} km (Késés: {Lista[i].KesesPercek} perc) - Munkabér: {(Lista[i].Csomagszam*600)+ (Lista[i].MegtettKm*100)+bonusz-levonas} Ft");
    teljesber += (Lista[i].Csomagszam * 600) + (Lista[i].MegtettKm * 100) + bonusz - levonas;
    osszcsomag += Lista[i].Csomagszam;
    if (((Lista[i].Csomagszam * 600) +(Lista[i].MegtettKm * 100) + bonusz - levonas) > legmagasabbber) { legmagasabbber = (Lista[i].Csomagszam * 600) + (Lista[i].MegtettKm * 100) + bonusz - levonas;legjobbdolgozo = Lista[i].Nev; }
    if (Lista[i].KesesPercek == 0) { nincskeses += 1; }
}
double atlagcsomag=(double)osszcsomag/Lista.Count;
Console.WriteLine("Összesített statisztika:");
Console.WriteLine($"Cég által kifizetett teljes munkabér: {teljesber} Ft");
Console.WriteLine($"Átlagos csomagszám futáronként: {atlagcsomag:F0} csomag");
Console.WriteLine($"Legmagasabb napi bér: {legjobbdolgozo} ({legmagasabbber} Ft)");
Console.WriteLine($"Késés nélkül dolgozó futárok száma: {nincskeses} fő");