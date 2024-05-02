import './Friend_Requests.css'


export default function FriendRequests() {


    return(
        <div class="Friend-requests">
            <img src="./images//avt/fr-rq.jpg" alt="fr-rq-avt" />
            <div class="avt-fr-rq">
                <div class="fr-rq-dc">
                    <p><b>Lan Huong</b></p>
                    <div class="fr-rq-dc-bot">
                        <div class="fr-1"><img src="./images/avt/fr-rq-bl-1.jpg" alt="fr-rq-bl-1" /></div>
                        <div class="fr-2"><img src="./images/avt/fr-rq-bl-2.jpg" alt="fr-rq-bl-2" /></div>
                        <span>3 mutual friends</span>
                    </div>
                </div>
                <div class="button-below-fr-rq">
                    <div class="butt-1"><p>Comfirm</p></div>
                    <div class="butt-2"><p>Delete</p></div>           
                </div>
            </div>
        </div>
    )
}