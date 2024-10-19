import "./Nav_middle.css"
import { Nav_middle_icon } from "./dataNavMiddle"

export default function NavMiddle(){
    const list_icon_nav_middle = Nav_middle_icon.map(Nav_middle_icon => 
        <li key={Nav_middle_icon.class}>
            <a href="#" className={Nav_middle_icon.class}>
                <img src={Nav_middle_icon.src}  alt="icon"></img>
            </a>
        </li>
    );
    
    return(
        <div className="nav-middle">
            <ul>{list_icon_nav_middle}</ul>
        </div>
    )
}