import './nav.css'
import NavLeft from "./Nav_left/Nav_left";
import NavMiddle from "./Nav_middle/Nav_middle";
import NavRight from "./Nav_right/Nav_right";


export default function Nav() {


    return(           
        <nav>
            <NavLeft/>
            <NavMiddle/>
            <NavRight/>
        </nav>
    )
}