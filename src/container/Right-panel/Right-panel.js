import './Right-panel.css'


import SponsoredSection from './Sponsored/Sponsored'
import FriendRequests from './Friend_Requests/Friend_Requests'
import Birthdays from './Birthdays/Birthdays'
import Friends from './Friends/Friend'


export default function RightPanel() {


    
    return(
        <div class="right-panel">
          <div class="name-tags"><p>Sponsored</p></div>
          <SponsoredSection/>
          {/* <hr class="line"/> */}
          <div class="name-tags"><p>Friend requests</p></div>
          <FriendRequests/>
          {/* <hr class="line"></hr> */}
          <div class="name-tags"><p>Birthdays</p></div>
          <Birthdays/>
          {/* <hr class="line"></hr> */}
          <div class="name-tags"><p>Contacts</p></div>
          <Friends/>
        </div>
    )
}