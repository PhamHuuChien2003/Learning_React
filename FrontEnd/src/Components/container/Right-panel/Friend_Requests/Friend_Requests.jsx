import './Friend_Requests.css'


export default function FriendRequests() {


    return(
        <div className="Friend-requests">
            <img src="./images//avt/fr-rq.jpg" alt="fr-rq-avt" />
            <div className="avt-fr-rq">
                <div className="fr-rq-dc">
                    <p><b>Lan Huong</b></p>
                    <div className="fr-rq-dc-bot">
                        <div className="fr-1"><img src="./images/avt/fr-rq-bl-1.jpg" alt="fr-rq-bl-1" /></div>
                        <div className="fr-2"><img src="./images/avt/fr-rq-bl-2.jpg" alt="fr-rq-bl-2" /></div>
                        <span>3 mutual friends</span>
                    </div>
                </div>
                <div className="button-below-fr-rq">
                    <div className="butt-1"><p>Comfirm</p></div>
                    <div className="butt-2"><p>Delete</p></div>           
                </div>
            </div>
        </div>
    )
}