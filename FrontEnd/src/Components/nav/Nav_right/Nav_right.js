import "./Nav_right.css"


export default function NavRight() {
    
    return(
        <div class="nav-right">
            <a href="#">
                <img src="./icon/menu.svg" alt="menu"></img>
            </a>
            <a href="#">
                <img src="./icon/facebook-messenger.svg" alt="mess"></img>
                <div class="nav-dot-bl"><p>3</p></div>
            </a>
            <a href="#">
                <img src="./icon/bell.svg" alt="bell"></img>
                <div class="nav-dot-bl"><p>1</p></div>
            </a>
            <span class="profile" style={{ backgroundImage: `url("./images/avt/selfpic.jpg")`}}>
                <div class="nav-dot-bl-pf"></div>
            </span>

        </div>
    )
}