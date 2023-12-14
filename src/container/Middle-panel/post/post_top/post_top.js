import './post_top.css'


export default function Top(Topx) {

    return(
        <div class="post-top">
                <div class={Topx.class_name_gr}>
                    <img src={Topx.src_avt_gr} alt={Topx.alt_avt_gr} />
                </div>
                <div class={Topx.class_name_avt}>
                    <img src={Topx.src_avt} />
                </div>
                <div class="post-info">
                    <p class="name-gr"><b>{Topx.name_gr}</b></p>
                    <div class="post-info-bl">
                        <p class="name-p-3">{Topx.name}</p>
                        <span class="dot">.</span>
                        <span class="time">{Topx.time}</span>
                    </div>
                </div>
                <br/>
            </div>
    )
}