import "./Left-panel.css"
import { dataLeftpanel1 } from "./data-1-Left-panel"
import { dataLeftpanel2 } from "./data-2-Left-panel"

export default function LeftPanel() {
   const List_icon_Left_panel_1 =  dataLeftpanel1.map(dataLeftpanel1 =>
         <li>
            <img src={dataLeftpanel1.src} alt={dataLeftpanel1.alt}></img>
            <p>{dataLeftpanel1.name}</p>
         </li>
    )
    const List_icon_Left_panel_2 = dataLeftpanel2.map(dataLeftpanel2=>
        <li>
           <img src={dataLeftpanel2.src} alt={dataLeftpanel2.alt}></img>
           <p>{dataLeftpanel2.name}</p>
        </li>
    )
    return(
    <>
    <div class="left-panel">
        <div class="left-panel-but" >
            <ul>
                <li>
                    <span class="profile" style={{ backgroundImage: `url("./images/avt/selfpic.jpg")`}}></span>
                    <p>Phạm Hữu Chiến</p>
                </li>
            </ul>
            <ul>{List_icon_Left_panel_1}</ul>
            <ul>
                <li>
                    <div class="down-chn"><a href="#"><i class="fa-solid fa-chevron-down"></i></a></div>
                    <p>See more</p>
                </li>
                <li>  
                    <p>Your shotcut</p>
                </li>
            </ul>
            <ul>{List_icon_Left_panel_2}</ul>
            <ul>
                <li>
                    <div class="down-chn"><a href="#"><i class="fa-solid fa-chevron-down"></i></a></div>
                    <p>See more</p>
                </li>
            </ul>
        </div>
        <div class="links">
            <div class="c4">
                <p>Privacy</p> <span class="dot">.</span>
                <p>Terms</p> <span class="dot">.</span>
                <p>Advertising</p> <span class="dot">.</span>
                <p>Ad Choice</p>
            </div>  
            <div class="c3l">  
                <p>Cookies</p> <span class="dot">.</span>
                <p>More</p> <span class="dot">.</span>
                <p>Meta c 2023</p> 
            </div>
        </div>
    </div>
    </>
    )
}