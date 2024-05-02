import './Like_des.css'

export default function LikeDescription(Topx) {


    return(
            <div class="like-descrip">
                    <div class="like-descrip-left">
                        <div class="img-1"><img src="./icon/Liked.svg" alt=""/></div>
                        <div class="img-2"><img src="./icon/Love.svg" alt=""/></div>
                        <p>{Topx.numoflike}</p>
                    </div>
                    <div class="like-descrip-right">
                        <p>{Topx.numofcmt}</p>
                        <img src="./icon/cmt.svg" alt="cmt"/>
                        <p>{Topx.numofshare}</p>
                        <img src="./icon/share.svg" alt="share" style={{scale:1.25}}/>
                    </div>
            </div>
    )
}