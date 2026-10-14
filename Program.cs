using Futarelszamolas;
List<Futar> Lista = new List<Futar>();
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

