import "./Nav_left.css"

import SearchSection from "./Search-section/Search-section"
import LogoFB from "./LogoFB/LogoFB"

export default function NavLeft() {
    return(
        <>
            <div class="nav_left">
                <LogoFB/>
                <SearchSection/>
            </div>
        </>
    )
}