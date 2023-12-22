import './publiccmt.css'

export default function Cmt(InforCmt) {
    
    const CmtImg =() =>(
        <div class="public-cmt">
                        <div class="cmt-top-4">
                            <div class="avt-in-public-cmt">
                                <img src={InforCmt.src_avt_in_cmt}/>
                            </div>
                            <div class="cmt-ct">
                                <div class="cmt-ct-top-4-1">
                                    <div class="name"><a><b>{InforCmt.name_cmt_er}</b></a></div>
                                    <div class="cmt-text"><p>{InforCmt.cmt_ct_w_1}</p></div>
                                </div>
                                <div class="cmt-ct-img-4-1">
                                    <img src={InforCmt.cmt_ct_img_1}/>
                                </div>
                                <div class="cmt-ct-bot">
                                    <ul>
                                        <li><p class="time">{InforCmt.time_cmt}</p></li>
                                        <li><p><b>Like</b></p></li>
                                        <li><p><b>Reply</b></p></li>
                                        <li><p><b>Share</b></p></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <div class="cmt-bot">
                            <div class="cmt-rep">
                                <img src="./images/down-right-ar.svg"/>
                                <p>View all {InforCmt.num_of_rep} replies</p>
                            </div>
                        </div>                      
                    </div>
    )

    const CmtW =()=>(
        <div class="public-cmt">
            <div class="cmt-top">
                <div class="avt-in-public-cmt">
                    <img src={InforCmt.src_avt_in_cmt}/>
                </div>
                <div class="cmt-ct">
                    <div class="cmt-ct-top-2">
                        <div class="name"><a><b>{InforCmt.name_cmt_er}</b></a></div>
                        <div class="cmt-text"><p><b>Quỳnh Nguyễn </b>{InforCmt.cmt_ct_w_1}</p></div>
                    </div>
                    <div class="cmt-ct-bot">
                        <ul>
                            <li><p class="time">{InforCmt.time_cmt}</p></li>
                            <li><p><b>Like</b></p></li>
                            <li><p><b>Reply</b></p></li>
                            <li><p><b>Share</b></p></li>
                        </ul>
                    </div>
                </div>
            </div>
                <div class="cmt-bot">
                    <div class="cmt-rep">
                        <img src="./images/down-right-ar.svg"/>
                        <p>View all {InforCmt.num_of_rep} replies</p>
                    </div>
                </div>                   
        </div>
    )

    return(
        <>

        </>
    )
}