import './Right-pannel.css'
import { DataFriendsRightPannel } from './dataFriend_Right_pannel'

export default function RightPannel() {
    
    
    const ListFriend = DataFriendsRightPannel.map(DataFriendsRightPannel =>
       <li>
            <a class="friend" >
                <div class="avt-person-left-panel">
                    <img src={DataFriendsRightPannel.src} alt={DataFriendsRightPannel.alt}></img>
                    <div class="dot-bl"><p></p></div>
                </div>
                <p class="name"><b>{DataFriendsRightPannel.name}</b></p>
            </a>
       </li>
    )

    return(
        <>
        

        </>
    )
}