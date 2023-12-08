import "./Left-pannel.css"
import { dataLeftpannel1 } from "./data-1-Left-pannel"
import { dataLeftpannel2 } from "./data-2-Left-pannel"

export default function LeftPanel() {
   const List_icon_Left_pannel_1 =  dataLeftpannel1.map(dataLeftpannel1 =>
         <li>
            <img src={dataLeftpannel1.src} alt={dataLeftpannel1.alt}></img>
            <p>{dataLeftpannel1.name}</p>
         </li>
    )
    const List_icon_Left_pannel_2 = dataLeftpannel2.map(dataLeftpannel2=>
        <li>
           <img src={dataLeftpannel2.src} alt={dataLeftpannel2.alt}></img>
           <p>{dataLeftpannel2.name}</p>
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
            <ul>{List_icon_Left_pannel_1}</ul>
            <ul>
                <li>
                    <div class="down-chn"><a href="#"><i class="fa-solid fa-chevron-down"></i></a></div>
                    <p>See more</p>
                </li>
                <li>  
                    <p>Your shotcut</p>
                </li>
            </ul>
            <ul>{List_icon_Left_pannel_2}</ul>
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