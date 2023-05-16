int tempo;
int velo;
tempo = Convert.ToInt32(Console.ReadLine());
velo = Convert.ToInt32(Console.ReadLine());
double media, t, v;
t = tempo;
v = velo;
media = (t * v) / 12;
Console.WriteLine(media.ToString("F3"));