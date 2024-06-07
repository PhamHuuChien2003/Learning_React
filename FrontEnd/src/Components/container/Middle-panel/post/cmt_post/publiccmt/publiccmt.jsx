import './publiccmt.css'

export default function CmtA(InfoCmt) {
    
    const CmtImg1 =() =>(
        <>
        <div className="public-cmt">
                        <div className="cmt-img-top">
                            <div className="avt-in-public-cmt">
                                <img src={InfoCmt.src_avt_in_cmt_1} alt=""/>
                            </div>
                            <div className="cmt-ct">
                                <div className="cmt-img-ct-top-1">
                                    <div className="name"><a href="#"><b>{InfoCmt.name_cmt_er_1}</b></a></div>
                                    <div className="cmt-text"><p>{InfoCmt.cmt_ct_w_1}</p></div>
                                </div>
                                <div className="cmt-img-ct-img-1">
                                    <img src={InfoCmt.cmt_ct_img_1} alt=""/>
                                </div>
                                <div className="cmt-ct-bot">
                                    <ul>
                                        <li><p className="time">{InfoCmt.time_cmt_1}</p></li>
                                        <li><p><b>Like</b></p></li>
                                        <li><p><b>Reply</b></p></li>
                                        <li><p><b>Share</b></p></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <div className="cmt-bot">
                            <div className="cmt-rep">
                                <img src="./icon/down-right-ar.svg" alt=""/>
                                <p>View all {InfoCmt.num_of_rep_1} replies</p>
                            </div>
                        </div>                      
        </div>
        <div className="public-cmt">
                        <div className="cmt-img-top">
                            <div className="avt-in-public-cmt">
                                <img src={InfoCmt.src_avt_in_cmt_2} alt=""/>
                            </div>
                            <div className="cmt-ct">
                                <div className="cmt-img-ct-top-2">
                                    <div className="name"><a><b>{InfoCmt.name_cmt_er_2}</b></a></div>
                                    <div className="cmt-text"><p>{InfoCmt.cmt_ct_w_2}</p></div>
                                </div>
                                <div className="cmt-img-ct-img-2">
                                    <img src={InfoCmt.cmt_ct_img_2} alt=""/>
                                </div>
                                <div className="cmt-ct-bot">
                                    <ul>
                                        <li><p className="time">{InfoCmt.time_cmt_2}</p></li>
                                        <li><p><b>Like</b></p></li>
                                        <li><p><b>Reply</b></p></li>
                                        <li><p><b>Share</b></p></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <div className="cmt-bot">
                            <div className="cmt-rep">
                                <img src="./icon/down-right-ar.svg" alt=""/>
                                <p>View all {InfoCmt.num_of_rep_2} replies</p>
                            </div>
                        </div>                      
                    </div>
  
    </>
  )
    const CmtW =()=>(
        <div className="public-cmt">
            <div className="cmt-top">
                <div className="avt-in-public-cmt">
                    <img src={InfoCmt.src_avt_in_cmt} alt=""/>
                </div>
                <div className="cmt-ct">
                    <div className={InfoCmt.class_cmt_ct}>
                        <div className="bordercmt"> 
                            <div className="name"><a><b>{InfoCmt.name_cmt_er}</b></a></div>
                            <div className="cmt-text"><p>{InfoCmt.cmt_ct_w_1}</p></div>
                        </div>
                       
                    </div>
                    <div className="cmt-ct-bot">
                        <ul>
                            <li><p className="time">{InfoCmt.time_cmt}</p></li>
                            <li><p><b>Like</b></p></li>
                            <li><p><b>Reply</b></p></li>
                            <li><p><b>Share</b></p></li>
                        </ul>
                    </div>
                </div>
            </div>
                <div className="cmt-bot">
                    <div className="cmt-rep">
                        <img src="./icon/down-right-ar.svg" alt=""/>
                        <p>View all {InfoCmt.num_of_rep} replies</p>
                    </div>
                </div>                   
        </div>
    )

    let Cmt1;
    InfoCmt.Num_Of_Show_Out_Cmt === '1' && ( Cmt1 = CmtW());
    InfoCmt.Num_Of_Show_Out_Cmt === '2' && ( Cmt1 = CmtImg1());


    return(<>{Cmt1}</>)
}