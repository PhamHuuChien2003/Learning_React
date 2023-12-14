import "./Left-panel.css"
import { dataLeftpanel1 } from "./data-1-Left-panel"
import { dataLeftpanel2 } from "./data-2-Left-panel"

export default function LeftPanel() {
   const List_icon_Left_panel_1 =  dataLeftpanel1.map(dataLeftpanel1 =>
         <li>
            <img src={dataLeftpanel1.src} alt={dataLeftpanel1.alt}></img>
            <p><b>{dataLeftpanel1.name}</b></p>
         </li>
    )
    const List_icon_Left_panel_2 = dataLeftpanel2.map(dataLeftpanel2=>
        <li>
           <img src={dataLeftpanel2.src} alt={dataLeftpanel2.alt}></img>
           <p><b>{dataLeftpanel2.name}</b></p>
        </li>
    )
    return(
    <>
    <div class="left-panel">
        <div class="left-panel-but" >
            <ul>
                <li>
                    <span class="profile" style={{ backgroundImage: `url("./images/avt/selfpic.jpg")`}}></span>
                    <p><b>Phạm Hữu Chiến</b></p>
                </li>
            </ul>
            <ul>{List_icon_Left_panel_1}</ul>
            <ul>
                <li>
                    <div class="down-chn"><a href="#"><i class="fa-solid fa-chevron-down"></i></a></div>
                    <p><b>See more</b></p>
                </li>
                <hr class="line"></hr>
                <li>  
                    <div class="ur-sc"><p><b>Your shotcut</b></p></div>
                </li>
            </ul>
            <ul>{List_icon_Left_panel_2}</ul>
            <ul>
                <li>
                    <div class="down-chn"><a href="#"><i class="fa-solid fa-chevron-down"></i></a></div>
                    <p><b>See more</b></p>
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