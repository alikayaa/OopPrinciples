using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatrancOOP
{
    public class BusinessRule
    {
        public bool CaprazIlerleyebilirMi(Kare bulunduguKare, Kare gidecegiKare)
        {
            bool ilerleyebilirMi = true;
            //x ve y koordinatları farkı eşit mi yani çapraz da mı
            if (Math.Abs(bulunduguKare.KonumX - gidecegiKare.KonumX) ==
                Math.Abs(bulunduguKare.KonumY - gidecegiKare.KonumY))
            {
                int x = bulunduguKare.KonumX;
                int y = bulunduguKare.KonumY;

                while (true)
                {
                    //yukarı sol çapraza ilerleme isteği mi
                    if (gidecegiKare.KonumY > bulunduguKare.KonumY && gidecegiKare.KonumX < bulunduguKare.KonumX)
                    {
                        x--;
                        y++;
                    }
                    //yukarı sağ çapraza ilerleme isteği mi
                    else if (gidecegiKare.KonumY > bulunduguKare.KonumY && gidecegiKare.KonumX > bulunduguKare.KonumX)
                    {
                        x++;
                        y++;
                    }
                    //aşağı sağ çapraza ilerleme isteği mi
                    else if (gidecegiKare.KonumY < bulunduguKare.KonumY && gidecegiKare.KonumX > bulunduguKare.KonumX)
                    {
                        x++;
                        y--;
                    }
                    //aşağı sol çapraza ilerleme isteği mi
                    else if (gidecegiKare.KonumY < bulunduguKare.KonumY && gidecegiKare.KonumX < bulunduguKare.KonumX)
                    {
                        x--;
                        y--;
                    }

                    //gidilmek istenen kareye gelindiyse
                    if (gidecegiKare.KonumX == x && gidecegiKare.KonumY == y)
                    {
                        Tas gidecegiYerdekiTas = Oyun.GetInstance().OyunTahtasi.Kareler.Where(i => i.KonumX == gidecegiKare.KonumX && i.KonumY == gidecegiKare.KonumY).First().UzerindeBulunanTas;
                        if(gidecegiYerdekiTas!=null)
                            if (bulunduguKare.UzerindeBulunanTas.TasRengi == gidecegiYerdekiTas.TasRengi)//takım arkadaşıysa
                                ilerleyebilirMi = false;
                        break;
                    }
                        
                    else
                    {
                        if (Oyun.GetInstance().OyunTahtasi.Kareler.Where(i => i.KonumX == x && i.KonumY == y).First().UzerindeBulunanTas != null)//yolda taş varsa ilerleyemez
                        {
                            ilerleyebilirMi = false;
                            break;
                        }
                    }
                }
            }
            else//gidilmek istenen kısım çaprazda değilse
            {
                ilerleyebilirMi = false;
            }
            return ilerleyebilirMi;
        }

        public bool YatayDikeyGidebilirMi(Kare bulunduguKare, Kare gidecegiKare)
        {
            bool ilerleyebilirMi = true;
            //gitmek istenen yer yatay veya dikeyde mi
            if (bulunduguKare.KonumX == gidecegiKare.KonumX || bulunduguKare.KonumY == gidecegiKare.KonumY)
            {
                int x = bulunduguKare.KonumX;
                int y = bulunduguKare.KonumY;

                while (true)
                {
                    //yukarı ilerleme isteği
                    if (gidecegiKare.KonumY > bulunduguKare.KonumY)
                    {
                        y++;
                    }
                    //aşağı ilerleme isteği
                    else if (gidecegiKare.KonumY < bulunduguKare.KonumY)
                    {
                        y--;
                    }
                    //sola ilerleme isteği
                    else if (gidecegiKare.KonumX < bulunduguKare.KonumX)
                    {
                        x--;
                    }
                    //sağa ilerleme isteği
                    else if (gidecegiKare.KonumX > bulunduguKare.KonumX)
                    {
                        x++;
                    }

                    //gidilmek istenen kareye gelindiyse
                    if (gidecegiKare.KonumX == x && gidecegiKare.KonumY == y)
                    {
                        Tas gidecegiYerdekiTas = Oyun.GetInstance().OyunTahtasi.Kareler.Where(i => i.KonumX == gidecegiKare.KonumX && i.KonumY == gidecegiKare.KonumY).First().UzerindeBulunanTas;
                        if(gidecegiYerdekiTas!=null)//gideği yerde taş varsa
                            if (bulunduguKare.UzerindeBulunanTas.TasRengi == gidecegiYerdekiTas.TasRengi)//takım arkadaşıysa
                                ilerleyebilirMi = false;
                        break;
                    }
                    else
                    {
                        if (Oyun.GetInstance().OyunTahtasi.Kareler.Where(i => i.KonumX == x && i.KonumY == y).First().UzerindeBulunanTas != null)//yolda taş varsa ilerleyemez
                        {
                            ilerleyebilirMi = false;
                            break;
                        }
                    }
                }
            }
            else
            {
                ilerleyebilirMi = false;
            }
            return ilerleyebilirMi;
        }

        public bool BirBirimIlerleyebilirMi(Kare bulunduguKare, Kare gidecegiKare)
        {
            bool ilerleyebilirMi = true;
            Kare k=Oyun.GetInstance().OyunTahtasi.Kareler.Where(i => i.KonumX == gidecegiKare.KonumX && i.KonumY == gidecegiKare.KonumY).FirstOrDefault();
            if (k!=null && k.UzerindeBulunanTas != null)//gideceği yerde başka biri varsa gidemez
            {
                    ilerleyebilirMi = false;
            }
            else//kendi takım arkadaşı yoksa
            {
                //sola ilerlemek istiyorsam
                if (bulunduguKare.KonumX - gidecegiKare.KonumX == 1 && bulunduguKare.KonumY == gidecegiKare.KonumY)
                {
                    ilerleyebilirMi = true;
                }
                //sağa ilerlemek istiyorsam
                else if (bulunduguKare.KonumX - gidecegiKare.KonumX == -1 && bulunduguKare.KonumY == gidecegiKare.KonumY)
                {
                    ilerleyebilirMi = true;
                }
                //yukarı ilerlemek istiyorsam
                else if (bulunduguKare.KonumY - gidecegiKare.KonumY == -1 && bulunduguKare.KonumX == gidecegiKare.KonumX)
                {
                    ilerleyebilirMi = true;
                }
                //aşağı ilerlemek istiyorsam
                else if (bulunduguKare.KonumY - gidecegiKare.KonumY == 1 && bulunduguKare.KonumX == gidecegiKare.KonumX)
                {
                    ilerleyebilirMi = true;
                }
                //sol üst çapraza ilerlemek istiyorsam
                else if (bulunduguKare.KonumY - gidecegiKare.KonumY == -1 && bulunduguKare.KonumX - gidecegiKare.KonumX == 1)
                {
                    ilerleyebilirMi = true;
                }
                //sağ üst çapraza ilerlemek istiyorsam
                else if (bulunduguKare.KonumY - gidecegiKare.KonumY == -1 && bulunduguKare.KonumX - gidecegiKare.KonumX == -1)
                {
                    ilerleyebilirMi = true;
                }
                //sol alt çapraza ilerlemek istiyorsam
                else if (bulunduguKare.KonumY - gidecegiKare.KonumY == 1 && bulunduguKare.KonumX - gidecegiKare.KonumX == 1)
                {
                    ilerleyebilirMi = true;
                }
                //sağ alt çapraza ilerlemek istiyorsam
                else if (bulunduguKare.KonumY - gidecegiKare.KonumY == 1 && bulunduguKare.KonumX - gidecegiKare.KonumX == -1)
                {
                    ilerleyebilirMi = true;
                }
                else
                {
                    ilerleyebilirMi = false;
                }
            }
            return ilerleyebilirMi;
        }

        public bool TekBirimDikeyGidebilirMi(Kare bulunduguKare, Kare gidecegiKare)
        {
            bool ilerleyebilirMi = true;
            if (Oyun.GetInstance().OyunTahtasi.Kareler.Where(i => i.KonumX == gidecegiKare.KonumX && i.KonumY == gidecegiKare.KonumY).First().UzerindeBulunanTas != null)//gideceği yerde herhangi başka bir taş varsa gidemez
            {
                ilerleyebilirMi = false;
            }
            else//gidecegi yer boştaysa
            {
                if (gidecegiKare.KonumX == bulunduguKare.KonumX)//aynı x ekseni üzerinde olacak
                {
                    if (bulunduguKare.UzerindeBulunanTas.TasRengi == TakimRengi.Beyaz)//beyaz piyon ise
                    {
                        if (bulunduguKare.KonumY == 1 && gidecegiKare.KonumY - bulunduguKare.KonumY <= 2)//yani ilk noktadaysa ve sadece tek veya çift atış yukarı çıkmaya çalışıyorsa
                        {
                            if (gidecegiKare.KonumY - bulunduguKare.KonumY == 2 && Oyun.GetInstance().OyunTahtasi.Kareler.Where(i => i.KonumX == gidecegiKare.KonumX && i.KonumY - 1 == gidecegiKare.KonumY).First().UzerindeBulunanTas==null)//çift atış çıkıyorsa ve yol müsait se
                            {
                                ilerleyebilirMi = true;
                            }
                            else if (gidecegiKare.KonumY - bulunduguKare.KonumY == 1)//tek atış çıkıyorsa
                            {
                                ilerleyebilirMi = true;
                            }
                        }
                        else if (gidecegiKare.KonumY - bulunduguKare.KonumY == 1)//ilk noktada değilse
                        {
                            ilerleyebilirMi = true;
                        }
                        else
                        {
                            ilerleyebilirMi = false;
                        }
                    }
                    else//siyah piyon ise
                    {
                        if (bulunduguKare.KonumY == 6 && bulunduguKare.KonumY-gidecegiKare.KonumY <= 2)//yani ilk noktadaysa ve sadece tek veya çift atış yukarı çıkmaya çalışıyorsa
                        {
                            if (bulunduguKare.KonumY - gidecegiKare.KonumY == 2 && Oyun.GetInstance().OyunTahtasi.Kareler.Where(i => i.KonumX == gidecegiKare.KonumX && i.KonumY + 1 == gidecegiKare.KonumY).First().UzerindeBulunanTas == null)//çift atış çıkıyorsa ve yol müsait se
                            {
                                ilerleyebilirMi = true;
                            }
                            else if (bulunduguKare.KonumY - gidecegiKare.KonumY == 1)
                            {
                                ilerleyebilirMi = true;
                            }
                        }
                        else if (bulunduguKare.KonumY - gidecegiKare.KonumY == 1)//ilk noktada değilse
                        {
                            ilerleyebilirMi = true;
                        }
                        else
                        {
                            ilerleyebilirMi = false;
                        }
                    }
                }
                else//aynı x ekseni üzernde değilse 
                {
                    ilerleyebilirMi = false;
                }
            }
            return ilerleyebilirMi;
        }

        public bool LSeklindeGidebilirMi(Kare bulunduguKare, Kare gidecegiKare)
        {
            bool ilerleyebilirMi = true;
            Tas gidecegiYerdekiTas = Oyun.GetInstance().OyunTahtasi.Kareler.Where(i => i.KonumX == gidecegiKare.KonumX && i.KonumY == gidecegiKare.KonumY).First().UzerindeBulunanTas;
            if (gidecegiYerdekiTas != null)//gideceği yerde herhangi başka bir taş varsa
            {
                if (bulunduguKare.UzerindeBulunanTas.TasRengi == gidecegiYerdekiTas.TasRengi)//kendi takım arkadaşı varsa gidemez
                {
                    ilerleyebilirMi = false;
                }
                else//rakip takım varsa
                {
                    ilerleyebilirMi = LGiderMi(bulunduguKare, gidecegiKare, ilerleyebilirMi);
                }
            }
            else//taş yoksa
            {
                ilerleyebilirMi = LGiderMi(bulunduguKare, gidecegiKare, ilerleyebilirMi);
            }
            return ilerleyebilirMi;
        }

        private static bool LGiderMi(Kare bulunduguKare, Kare gidecegiKare, bool ilerleyebilirMi)
        {
            int[] xLer =
                {
                    bulunduguKare.KonumX+1,    
                    bulunduguKare.KonumX+2,
                    bulunduguKare.KonumX+2,
                    bulunduguKare.KonumX+1,
                    bulunduguKare.KonumX-1,
                    bulunduguKare.KonumX-2,
                    bulunduguKare.KonumX-2,
                    bulunduguKare.KonumX-1
                };
            int[] yLer = 
                { 
                    bulunduguKare.KonumY-2,    
                    bulunduguKare.KonumY-1,
                    bulunduguKare.KonumY+1,
                    bulunduguKare.KonumY+2,
                    bulunduguKare.KonumY+2,
                    bulunduguKare.KonumY+1,
                    bulunduguKare.KonumY-1,
                    bulunduguKare.KonumY-2
                };

            for (int i = 0; i < 8; i++)
            {
                if (gidecegiKare.KonumX == xLer[i] && gidecegiKare.KonumY == yLer[i])
                {
                    ilerleyebilirMi = true;
                    break;
                }
                else
                {
                    ilerleyebilirMi = false;
                }
            }
            return ilerleyebilirMi;
        }

        public bool PiyonlaYiyebilirMi(Kare bulunduguKare, Kare gidecegiKare)
        {
            bool yiyebilirMi = false;
            Tas gidecegiYerdekiTas = Oyun.GetInstance().OyunTahtasi.Kareler.Where(i => i.KonumX == gidecegiKare.KonumX && i.KonumY == gidecegiKare.KonumY).First().UzerindeBulunanTas;
            if (gidecegiYerdekiTas != null)//gideceği yerde herhangi başka bir taş varsa
            {
                if (bulunduguKare.UzerindeBulunanTas.TasRengi == gidecegiYerdekiTas.TasRengi)//kendi takım arkadaşı varsa yiyemez
                {
                    yiyebilirMi = false;
                }
                else//rakipse
                {
                    if (bulunduguKare.UzerindeBulunanTas.TasRengi == TakimRengi.Beyaz)
                    {
                        if (bulunduguKare.KonumX - gidecegiKare.KonumX == 1 && gidecegiKare.KonumY - bulunduguKare.KonumY == 1)
                            yiyebilirMi = true;
                        if (bulunduguKare.KonumX - gidecegiKare.KonumX == -1 && gidecegiKare.KonumY - bulunduguKare.KonumY == 1)
                            yiyebilirMi = true;
                    }
                    else
                    {
                        if (bulunduguKare.KonumX - gidecegiKare.KonumX == -1 && gidecegiKare.KonumY - bulunduguKare.KonumY == -1)
                            yiyebilirMi = true;
                        if (bulunduguKare.KonumX - gidecegiKare.KonumX == 1 && gidecegiKare.KonumY - bulunduguKare.KonumY == -1)
                            yiyebilirMi = true;
                    }
                }
            }
            else//gideceği yerde taş yoksa yiyemez
            {
                yiyebilirMi = false;
            }

            
            return yiyebilirMi;
        }
    }

}
