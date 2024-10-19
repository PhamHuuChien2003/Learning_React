import './Friends.css'
import { DataFriendsRightPannel } from './dataFriend_Right_pannel'


export default function Friends() {
    
    const ListFriend = DataFriendsRightPannel.map(DataFriendsRightPannel =>
        <a className="friend" href='#' key={DataFriendsRightPannel.id}>
            <div className="avt-person-left-panel">
                <img src={DataFriendsRightPannel.src} alt={DataFriendsRightPannel.alt}></img>
                <div className="dot-bl"><p></p></div>
            </div>
            <p className="name"><b>{DataFriendsRightPannel.name}</b></p>
        </a>
    )

    return(
        <div className="friends-section">
        {ListFriend}
        </div>
    )
}