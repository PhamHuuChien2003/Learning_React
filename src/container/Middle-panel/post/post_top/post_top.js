import './post_top.css'

export default function Top(Topx) {

    var postTopGr = () => (
        <div class="post-top">
                <div class="avt-gr-post">
                    <img src={Topx.src_avt_gr} alt={Topx.alt_avt_gr} />
                </div>
                <div class="avt-person-gr-post">
                    <img src={Topx.src_avt} alt={Topx.alt_avt} />
                </div>
                <div class="post-info">
                    <p class="name-gr"><b>{Topx.name_gr}</b></p>
                    <div class="post-info-bl">
                        <p class="name-p-3">{Topx.name_p}</p>
                        <span class="dot">.</span>
                        <span class="time">{Topx.time}</span>
                    </div>
                </div>
                <br/>
        </div>
    )

    var postTop =()=>(
        <div class="post-top">
                <div class="avt-person-post">
                <img src={Topx.src_avt} alt={Topx.alt_avt} />
                </div>
                <div class="post-info">
                    <p class="name"><b>{Topx.name_p}</b></p>
                    <span class="time">{Topx.time}</span>
                    <span class="dot">.</span>
                    <i class="fa-solid fa-earth-americas" style={{color: "#6f7d95"}}></i>
                </div>
                <br/>
        </div>
    )

    return(
        <>
           {Topx.gr==='false' ? postTop() : postTopGr()}
        </>
    )
}