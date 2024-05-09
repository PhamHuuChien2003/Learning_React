import './Friends.css'
import { DataFriendsRightPannel } from './dataFriend_Right_pannel'


export default function Friends() {
    
    const ListFriend = DataFriendsRightPannel.map(DataFriendsRightPannel =>
        <a class="friend" >
            <div class="avt-person-left-panel">
                <img src={DataFriendsRightPannel.src} alt={DataFriendsRightPannel.alt}></img>
                <div class="dot-bl"><p></p></div>
            </div>
            <p class="name"><b>{DataFriendsRightPannel.name}</b></p>
        </a>
    )

    return(
        <div class="friends-section">
        {ListFriend}
        </div>
    )
}