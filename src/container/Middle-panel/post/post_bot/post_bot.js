import "./post_bot.css"

import ButtonBelow from "./button_below/button_below"
import LikeDescription from "./Like_des/Like_des"

export default function PostBot(Botx) {
    
    return(
        <div className="post-bot">
            <LikeDescription {...Botx} />
            <hr className="line"></hr>
            <ButtonBelow/>
            <br/>
            <hr className="line"/>
            <br/>
        </div>
    )
}