import './Like_des.css'

export default function LikeDescription(Topx) {


    return(
            <div className="like-descrip">
                    <div className="like-descrip-left">
                        <div className="img-1"><img src="./icon/Liked.svg" alt=""/></div>
                        <div className="img-2"><img src="./icon/Love.svg" alt=""/></div>
                        <p>{Topx.numoflike}</p>
                    </div>
                    <div className="like-descrip-right">
                        <p>{Topx.numofcmt}</p>
                        <img src="./icon/cmt.svg" alt="cmt"/>
                        <p>{Topx.numofshare}</p>
                        <img src="./icon/share.svg" alt="share" style={{scale:1.25}}/>
                    </div>
            </div>
    )
}