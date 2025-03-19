﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristGuide.Models;

namespace TouristGuide.Services
{
    public static class DataManager
    {
        private static List<Continent> Continents;
        public static List<Continent> GetContinents()
        {
            // Тестовая инициализация, позже будет подгрузка из базы данных
            // При использования JSON файлов теряется перекрестные ссылки и для учитывания перекрестных ссылок потребуется создать кастомный серриализатор + добавить поля в модели, на данный моент не будет реализовываться
            if(Continents == null)
            {
                List<Continent> newListContinents = new List<Continent>
                {
                    new Continent{Name = "Азия", 
                        Description = "А́зия — крупнейшая часть света по территории, численности населения и плотности. Образует вместе с Европой материк Евразию, занимая более 83 % его общей площади. Площадь (вместе с островами) составляет около 44,5 млн км². По населению Азия превосходит совокупное население всех остальных частей света. На октябрь 2022 года население Азии — 4,72 млрд человек, что составляет примерно 60 % населения Земли. Ныне Азия является крупнейшим развивающимся регионом в мире.",
                        MapPhoto = "/Resources/Images/Asia_(orthographic_projection).svg.png"},
                    new Continent{Name = "Европа",
                        Description = "Евро́па — часть света в Северном полушарии Земли, омываемая Атлантическим океаном на западе, Северным Ледовитым океаном на севере и имеющая площадь около 10,3 млн км². Вместе с Азией Европа образует обширный континент Евразия, занимая примерно 17 % её общей площади, и является одной из самых маленьких по величине частей света в мире, немногим больше Океании.\r\n\r\nВ Европе проживает чуть меньше 750 миллионов человек, что делает её четвёртой по численности населения частью света после Азии, Африки и Америки. В Европе находится 50 государств.",
                        MapPhoto = "/Resources/Images/Europe_orthographic_Caucasus_Urals_boundary_(with_borders).svg.png"},
                    new Continent{Name = "Северная Америка",
                        Description = "Се́верная Аме́рика (англ. North America, фр. Amérique du Nord, исп. América del Norte, Norteamérica, аст. Ixachitlān Mictlāmpa) — один из шести материков планеты Земля, расположенный на севере Западного полушария Земли, занимающий 1/6 часть суши и имеющий наибольшее количество островов.\r\n\r\nПлощадь материковой Северной Америки — 20 360 000 км², а с учётом островов — 24 365 000 км². К островам Северной Америки относятся Гренландия, Канадский Арктический архипелаг, Вест-Индия, Алеутские острова и другие.\r\n\r\nНаселение Северной Америки составляет ~579 млн человек, что составляет 7 % от населения мира. В пределах материка часто выделяют Североамериканский регион, объединяющий США, Канаду, Гренландию, Сен-Пьер и Микелон и Бермуды. Северная Америка, как и Австралия, является материком, где нет стран без выхода к морю.",
                        MapPhoto = "/Resources/Images/Location_North_America.svg.png"},
                    new Continent{Name = "Южная Америка",
                        Description = "Ю́жная Аме́рика — один из шести материков планеты Земля, расположенный на юге Западного полушария. Омывается на западе Тихим океаном, на востоке — Атлантическим, на севере — Карибским морем, которое является естественным рубежом между двумя Америками. Панамский перешеек на северо-западе материка соединяет Южную Америку с Северной. Оба материка составляют часть света Америка.\r\n\r\nВ состав Южной Америки также входят различные острова, большинство из которых принадлежит странам континента. Страны Южной Америки, которые граничат с Карибским морем — включая Колумбию, Венесуэлу, Гайану, Суринам, Французскую Гвиану и Панаму — известны как Карибская Южная Америка.\r\n\r\nПлощадь континента — 17,84 млн км² (4-е место среди континентов; по площади лишь чуть больше России), население — 438 039 139 (2021 г.) человек (4-е место среди континентов).",
                        MapPhoto = "/Resources/Images/South_America_(orthographic_projection).svg.png"},
                    new Continent{Name = "Африка",
                        Description = "А́фрика — второй по площади материк после Евразии, омывается Средиземным морем с севера, Красным — с северо-востока, Атлантическим океаном с запада и Индийским океаном с востока, и обоими океанами с юга, с разделением по 20° в. д.\r\n\r\nАфрикой называется также часть света, состоящая из материка Африка и прилегающих островов. Площадь Африки без островов составляет 29,2 млн км², с островами — около 30,3 млн км², покрывая, таким образом, 6 % общей площади поверхности Земли и 20,4 % поверхности суши. По площади Африка на 32 % меньше Азии и Америки, являясь после них третьей по величине частью света. На территории Африки расположено 55 государств (включая зависимые территории). Население составляет 1,5 млрд. чел. (2024 год около 21 % населения Земли) и, таким образом, сравнимо с самыми населёнными государствами мира — Китаем и Индией.\r\n\r\nАфрика считается прародиной человечества: именно здесь нашли самые древние останки рода Homo и вида Homo sapiens, и его вероятных предков, включая сахелантропов, Australopithecus africanus, A. afarensis, Homo erectus, H. habilis и H. ergaster.\r\n\r\nАфриканский континент пересекает экватор и имеет много климатических зон; это единственный континент, протянувшийся от северного субтропического климатического пояса до южного субтропического. Из-за недостатка постоянных осадков и орошения — равно как ледников или водоносного горизонта горных систем — естественного регулирования климата нигде, кроме побережий, практически не наблюдается.\r\n\r\nИзучением культурных, экономических, политических и социальных проблем Африки занимается наука африканистика.",
                        MapPhoto = "/Resources/Images/Africa_(orthographic_projection).svg.png"},
                    new Continent{Name = "Океания",
                        Description = "Океа́ния — собирательное название обширного скопления островов и атоллов в центральной и западной частях Тихого океана. Границы Океании условны. Западной границей принято считать остров Новая Гвинея, восточной — остров Пасхи. Как правило, в Океанию не включают Австралию, а также острова и архипелаги юго-восточной Азии, Дальнего Востока и Северной Америки. В разделе географии, страноведение, Океанию изучает самостоятельная дисциплина — океанистика.\r\n\r\nТермин «Океания» впервые употребил французский географ датского происхождения Конрад Мальт-Брюн.",
                        MapPhoto = "/Resources/Images/Oceania_(orthographic_projection).svg.png"},
                    new Continent{Name = "Антарктида",
                        Description = "Антаркти́да (от греч. anti — против и arktos — Медведица, отсюда вообще — север[1]) — континент, расположенный на самом юге Земли. Центр Антарктиды примерно совпадает с Южным географическим полюсом. Омывается Атлантическим, Индийским и Тихим океанами. С 2000 года воды, омывающие Антарктиду к югу от 60° ю. ш., по решению Международной гидрографической организации называются Южным океаном.\r\n\r\nПлощадь континента составляет около 14 107 100 км² (из них шельфовые ледники — 935 000 км², острова — 75 700 км²)[источник не указан 83 дня]. С севера на юг протяжённость составляет более 3000 км, а с запада на восток — более 4500 км. Средняя высота поверхности Антарктиды самая большая из всех континентов. Помимо полюса холода, в Антарктиде располагаются точки самой низкой относительной влажности воздуха, самого сильного и продолжительного ветра и самой интенсивной солнечной радиации.\r\n\r\nАнтарктидой также называют часть света, состоящую из материка Антарктиды и прилегающих островов.\r\n\r\nАнтарктида не принадлежит ни одному государству мира. На территории Антарктиды разрешается проведение только научной деятельности. Антарктида является единственным незаселённым и самым неосвоенным континентом Земли.",
                        MapPhoto = "/Resources/Images/Antarctica_(orthographic_projection).svg.png"}
                };
                Country Russia = new Country
                {
                    Name = "Россия",
                    Currency = "российский рубль, ₽ (RUB, 1991—1998 гг. — RUR)",
                    FlagPhoto = "/Resources/Images/Flag_of_Russia.svg.webp",
                    GeneralInfo = "Росси́я, или Росси́йская Федера́ция[e] (сокр. РФ[f]), — государство в Восточной Европе и Северной Азии. Россия — крупнейшее государство в мире, её территория в международно признанных границах составляет 17 098 246 км²[22]. Население страны вместе с аннексированным украинским Крымом составляет 146 150 789 человек (2024; 9-е место в мире). Столица — Москва. Государственный язык на всей территории страны — русский, в ряде регионов России также установлены свои государственные и официальные языки. Денежная единица — российский рубль.\r\n\r\nРоссия — многонациональное государство с широким этнокультурным многообразием[25]. Согласно результатам переписей населения России 2010 года, а также переписи аннексированных Крыма и Севастополя 2014 года, в стране живут представители свыше 190 национальностей, среди которых русские составляют свыше 80 %, а русским языком владеют свыше 99,4 % россиян[26]. Бо́льшая часть населения (около 75 %) в религиозном отношении относит себя к православию[27], что делает Россию страной с самым многочисленным православным населением в мире.\r\n\r\nРоссия — федеративная президентско-парламентская республика[5]. С 31 декабря 1999 года (с перерывом в 2008—2012 годах, когда президентом был Дмитрий Медведев) должность президента России занимает Владимир Путин. C 16 января 2020 года в должности председателя правительства находится Михаил Мишустин. За годы правления Путина политический режим России сменился с демократического[28] на авторитарную диктатуру[29][30].\r\n\r\nРоссия граничит с 18 государствами мира (с шестнадцатью — по суше и с двумя — по морю). В состав России по её конституции входят 89 субъектов[g], 48 из которых — области, 24[g] — республики, 9 — края, 3[b] — города федерального значения, 4 — автономные округа и 1 — автономная область. Всего в стране около 157 тысяч населённых пунктов[31]."
                };
                Russia.Continents.Add(newListContinents[0]);
                Russia.Continents.Add(newListContinents[1]);
                newListContinents[0].Countries.Add(Russia);
                newListContinents[1].Countries.Add(Russia);
                Country Armenia = new Country
                {
                    Name = "Армения",
                    Currency = "армянский драм ֏ (AMD, код 51)",
                    FlagPhoto = "/Resources/Images/Flag_of_Armenia.svg.png",
                    GeneralInfo = "Арме́ния (арм. Հայաստանо файле [hɑjɑsˈtɑn]), официальное название — Респу́блика Арме́ния (арм. Հայաստանի Հանրապետություն [hɑjɑstɑˈni hɑnɾɑpɛtuˈtʰjun]) — государство в Закавказье, расположенное на севере Передней Азии, на северо-востоке Армянского нагорья. Выхода к морю не имеет."
                };
                Armenia.Continents.Add(newListContinents[0]);
                newListContinents[0].Countries.Add(Armenia);
                Country Gemany = new Country
                {
                    Name = "Германия",
                    Currency = "евро (EUR, код 978)",
                    FlagPhoto = "/Resources/Images/Flag_of_Germany.svg.png",
                    GeneralInfo = "Герма́ния[10] (нем. Deutschland МФА: [ˈdɔʏtʃlant]о файле), полное официальное название — Федерати́вная Респу́блика Герма́ния (нем. Bundesrepublik Deutschland; аббр. ФРГ, нем. BRD)[11] — государство в Центральной Европе со столицей в Берлине[12]. Площадь территории — 357 684 км²[4]. Численность населения на январь 2023 года — 84,4 млн человек. Занимает 19-е место в мире по численности населения (1-е место в ЕС, при учёте России и Турции 3-е в Европе) и 62-е в мире по территории (8-е в Европе)."
                };
                Gemany.Continents.Add(newListContinents[0]);
                newListContinents[0].Countries.Add(Gemany);
                MonthWeather TestSum = new MonthWeather
                {
                    Mounth = "Лето",
                    MinTemp = 10,
                    MaxTemp = 30,
                    Precipitation = "200 ml",
                    Description = "Не жарко",
                };
                MonthWeather TestWinter = new MonthWeather
                {
                    Mounth = "Зима",
                    MinTemp = -20,
                    MaxTemp = -5,
                    Precipitation = "200 ml",
                    Description = "Не холодно",
                };
                MonthWeather TestAutumn = new MonthWeather
                {
                    Mounth = "Осень",
                    MinTemp = -2,
                    MaxTemp = 10,
                    Precipitation = "200 ml",
                    Description = "Сыро",
                };
                MonthWeather TestSpring = new MonthWeather
                {
                    Mounth = "Весна",
                    MinTemp = -5,
                    MaxTemp = 15,
                    Precipitation = "200 ml",
                    Description = "Простудно",
                };

                Location Moscow = new Location
                {
                    Name = "Москва",
                    TimeZone = "UTC+3:00",
                    Country = Russia
                };
                Moscow.Photos.Add("/Resources/Images/Moscow_Kremlin_View_from_Kamennyi_Bridge.jpg");
                Moscow.Climate.Add(TestWinter);
                Moscow.Climate.Add(TestSpring);
                Moscow.Climate.Add(TestSum);
                Moscow.Climate.Add(TestAutumn);
                Russia.Locations.Add(Moscow);
                Continents = newListContinents;
            }
            return Continents;
        }
    }
}
