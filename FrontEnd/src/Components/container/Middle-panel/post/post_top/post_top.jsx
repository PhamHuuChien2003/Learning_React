import './post_top.css'

export default function Top(Topx) {

    // var postTopGr = () => (
    //     <div className="post-top">
    //             <div className="avt-gr-post">
    //                 <img src={Topx.src_avt_gr} alt={Topx.alt_avt_gr} />
    //             </div>
    //             <div className="avt-person-gr-post">
    //                 <img src={Topx.src_avt} alt={Topx.alt_avt} />
    //             </div>
    //             <div className="post-info">
    //                 <p className="name-gr"><b>{Topx.name_gr}</b></p>
    //                 <div className="post-info-bl">
    //                     <p className="name-p-3">{Topx.name_p}</p>
    //                     <span className="dot">.</span>
    //                     <span className="time">{Topx.time}</span>
    //                 </div>
    //             </div>
    //             <br/>
    //     </div>
    // )
    console.log("user",Topx.UserId);
    var postTop =()=>(
        <div className="post-top">
                <div className="avt-person-post">
                <img src={Topx.src_avt} alt={Topx.alt_avt} />
                </div>
                <div className="post-info">
                    <p className="name"><b>{Topx.name_p}</b></p>
                    <span className="time">{Topx.time}</span>
                    <span className="dot">.</span>
                    <i className="fa-solid fa-earth-americas" style={{color: "#6f7d95"}}></i>
                </div>
                <br/>
        </div>
    )

    return(
        <>
           {/* {Topx.gr==='false' ? postTop() : postTopGr()} */}
           {postTop()}
        </>
    )
}