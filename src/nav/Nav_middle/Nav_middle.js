import "./Nav_middle.css"
import { Nav_middle_icon } from "./dataNavMiddle"

export default function Nav_middle(){
    const list_icon_nav_middle = Nav_middle_icon.map(Nav_middle_icon => 
        <li>
            <a href="#" class={Nav_middle_icon.class}>
                <img src={Nav_middle_icon.src}></img>
            </a>
        </li>
    
    );
    
    return(
        <div class="nav-middle">
            <ul>{list_icon_nav_middle}</ul>
        </div>
    )
}