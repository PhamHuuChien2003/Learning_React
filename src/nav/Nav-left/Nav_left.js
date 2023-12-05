import "./Nav_left.css"

import Search_section from "./Search-section/Search-section"
import LogoFB from "./LogoFB/LogoFB"

export default function Nav_left() {
    return(
        <>
            <div class="nav_left">
                <LogoFB/>
                <Search_section/>
            </div>
        </>
    )
}