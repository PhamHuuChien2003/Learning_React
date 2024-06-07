import './Right-panel.css'


import SponsoredSection from './Sponsored/Sponsored'
import FriendRequests from './Friend_Requests/Friend_Requests'
import Birthdays from './Birthdays/Birthdays'
import Friends from './Friends/Friend'


export default function RightPanel() {


    
    return(
        <div className="right-panel">
          <div className="name-tags"><p>Sponsored</p></div>
          <SponsoredSection/>
          <hr className="line"/>
          <div className="name-tags"><p>Friend requests</p></div>
          <FriendRequests/>
          <hr className="line"/>
          <div className="name-tags"><p>Birthdays</p></div>
          <Birthdays/>
          <hr className="line"/>
          <div className="name-tags"><p>Contacts</p></div>
          <Friends/>
        </div>
    )
}