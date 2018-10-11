namespace MindBubbles.Controllers
{
    using MindBubbles.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Web;
    using System.Web.Mvc;
    using MindBubbles.Logic;

    public class BubbleCreateController : Controller
    {
        public int cellsNumber;
        private  Logic logic = new Logic(); 

        
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BubbleCreate(InputStringModel inputStringModel)
        {
           // inputStringModel.InputString = "1 PODPOROVAT PODNIKÁNÍ A ZAMESTNANOST|||||1.1 Prilákat nové investory do území||||1.2 Zlepšit informovanost a spolupráci smerem k podnikatelum||||1.3 Pracovat na zvýšení podílu zamestnaných osob||||2 ROZVÍJET TECHNICKOU INFRASTRUKTURU|||||2.1 Pripravit modernizaci COV - technologie||||2.2 Dokoncit/Rozšírit vodovod ||||2.4 Postupne obnovovat vodovodní a kanalizacní síte  ||||2.5 Budovat inženýrské síte pro výstavbu nových rodinných domu||||2.6 Optimalizovat tepelné hospodárství Mesta Vrbna pod Pradedem||||3 ROZVÍJET OBCANSKOU VYBAVENOST|||||3.1 Zvýšit nabídku kvalitních zdravotnických služeb ||||3.2 Zvyšovat úroven škol||||3.3 Zlepšit stav bytového fondu mesta||||3.4 Regenerace a modernizace verejných prostranství||||3.5 Rozšírit nabídku služeb||||3.6 Modernizovat a udržovat mestský mobiliár||||3.7 Chránit a opravit nemovité kulturní památky a památky místního významu||||3.8 Rozvíjet a zlepšit stav hrbitovu||||3.9 Pecovat o zelen/budovat plochy zelene||||3.10 Realizovat projekt Výstavby hasicské zbrojnice||||4 ROZVÍJET DOPRAVU|||||4.1 Zlepšení stavu komunikací, silnic ||||4.2 Rozšírit kapacitu parkovacích míst||||4.3 Zlepšit stav/vybudovat chodníky||||4.4 Doplnit a udržovat zastávky hromadné dopravy ||||4.5 Optimalizovat návaznost a cetnost spoju ve smeru do Bruntálu, Krnova, Jeseníku a Olomouce||||4.6 Zlepšit a rozšírit navigacní systém ve meste - viz. bod 1.2.3.1||||4.7 Vybudovat dostatecnou a kvalitní sít cyklostezek (zajistit bezpecný pohyb cyklistu po meste)||||5 ZLEPŠOVAT STAV ŽIVOTNÍHO PROSTREDÍ|||||5.1 Realizovat protipovodnová a protierozní opatrení||||5.2 Zlepšit kvalitu reky Opavy (razena do II. tr. jakosti - mírne znecištená voda, jelikož vykazuje cástecné organické znecištení a zatížení fosforem) ||||5.3 Minimalizovat znecištení ovzduší vlivem lokálních topeništ v zimním období||||5.5 Sanace a následné využití lokalit s ekologickými zátežemi a brownfieldu ||||5.6 Chránit prírodní hodnoty||||6 ZAJISTIT BEZPECNOST |||||6.1 Vytváret bezpecné prostredí a trvale snižovat kriminalitu páchanou ve meste ||||6.2 Zajištovat podmínky pro dopravní bezpecnost||||6.3 Informovanost pri krizových situacích |||";

            return View(logic.GenerateBubbles(inputStringModel));

        }

       


        public ActionResult InputSource()
        {
            return View();
        }


    }
}