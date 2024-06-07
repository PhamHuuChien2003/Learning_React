import './post_content.css'

export default function Content(Topx) {

    const WordOnly=() => (
        <div className="post-content">
                <div className="bg-ct">
                    <p>
                        <b>{Topx.para1}</b>
                    </p>
                    <p>
                        <b>{Topx.para2}</b>
                    </p>
                    <br/>
                </div>
            </div>
    );

    const SinglepicWithCap=() =>(
        <div className="post-content">
                <p className="cap">{Topx.cap}</p>
                <p className="hashtag">{Topx.hastag}</p>
                <img src={Topx.src_pic_content1} alt="pic"/>
            </div>
    );

    const Vids=()=>(
        <div className="post-content">
                <p className="cap">{Topx.cap}</p>
                <video  width="480" height="270" controls autoPlay>
                    <source src={Topx.src_vid} type="video/mp4"/>
                </video>  
            </div>
    );

    const Album=()=>(
        <div className="post-content">
                <div className="bg-ct">
                    <p className="cap">{Topx.cap}</p>
                    <p className="hashtag">{Topx.hastag}</p>
                    <div className="album-img">
                        <div className="i2-img-ln-1">
                            <div className="img-1-album"> 
                                <img src={Topx.src_pic_content1} alt="p1a"/>
                            </div>
                            <div className="img-2-album"> 
                                <img src={Topx.src_pic_content2} alt="p2a"/>
                            </div>
                        </div>

                        <div className="i3-img-ln-2">
                            <div className="img-3-album"> 
                                <img src={Topx.src_pic_content3} alt="p3a"/>
                            </div>
                            <div className="img-4-album"> 
                                <img src={Topx.src_pic_content4} alt="p4a"/>
                            </div>
                            <div className="img-5-album"> 
                                <img src={Topx.src_pic_content5} alt="p5a"/>
                            </div>
                            <div className="blur-more-img">
                                <p>+{Topx.num_p}</p>
                            </div> 
                        </div>                       
                    </div>
                    <br/>
                </div>
            </div>
    );
    

    const Vote=()=>(

        <div className="post-content">
                <p className="cap">{Topx.cap}</p>
                <div className="Vote-sections">
                    <ul>
                        <li>
                            <div className="vote">
                                <div className="percent-voted-1"></div>
                                <div className="square-choose">
                                    <div className="setting-check-mark">
                                        <input type="checkbox"/>
                                    </div>
                                </div>
                                <div className="name-1st-choice"><span className="name-choice-1"><b>{Topx.name_choice_1}</b></span></div>
                                <div className="result-percent-voted">
                                    <span>{Topx.percent_1}</span>
                                    <i className="fa-solid fa-chevron-right" style={{color:"#6b6b6b"}}></i>
                                </div>
                            </div>
                        </li>
                        <li>
                            <div className="vote">
                                <div className="percent-voted-2"></div>
                                <div className="square-choose">
                                    <div className="setting-check-mark">
                                        <input type="checkbox"/>
                                    </div>
                                </div>
                                <div className="name-2nd-choice">
                                    <span className="added-by">Added by <b>{Topx.Added_by_2}</b></span>
                                    <span className="name-choice"><b>{Topx.name_choice_2}</b></span>
                                </div>
                                <div className="result-percent-voted">
                                    <span>{Topx.percent_2}</span>
                                    <i className="fa-solid fa-chevron-right" style={{color: "#6b6b6b"}}></i>
                                </div>
                            </div>
                        </li>
                        <li>
                            <div className="vote">
                                <div className="percent-voted-3"></div>
                                <div className="square-choose">
                                    <div className="setting-check-mark">
                                        <input type="checkbox"/>
                                    </div>
                                </div>
                                <div className="name-3rd-choice">
                                    <span className="added-by">Added by <b>{Topx.Added_by_3}</b></span>
                                    <span className="name-choice"><b>{Topx.name_choice_3}</b></span>
                                </div>
                                <div className="result-percent-voted">
                                    <span>{Topx.percent_3}</span>
                                    <i className="fa-solid fa-chevron-right" style={{color: "#6b6b6b"}}></i>
                                </div>

                            </div>
                        </li>
                        <li>
                            <div className="vote">
                                <div className="percent-voted-4"></div>
                                <div className="square-choose">
                                    <div className="setting-check-mark">
                                        <input type="checkbox"/>
                                    </div>
                                </div>
                                <div className="name-4th-choice">
                                    <span className="added-by">Added by <b>{Topx.Added_by_4}</b></span>
                                    <span className="name-choice"><b>{Topx.name_choice_4}</b></span>
                                </div>
                                <div className="result-percent-voted">
                                    <span>{Topx.percent_4}</span>
                                    <i className="fa-solid fa-chevron-right" style={{color: "#6b6b6b"}}></i>
                                </div>

                            </div>
                        </li>
                        <li>
                            <div className="vote">
                                <div className="percent-voted-5"></div>
                                <div className="square-choose">
                                    <div className="setting-check-mark">
                                        <input type="checkbox"/>
                                    </div>
                                </div>
                                <div className="name-5th-choice">
                                    <span className="added-by">Added by <b>{Topx.Added_by_5}</b></span>
                                    <span className="name-choice"><b>{Topx.name_choice_5}</b></span>
                                </div>
                                <div className="result-percent-voted">
                                    <span>{Topx.percent_5}</span>
                                    <i className="fa-solid fa-chevron-right" style={{color:"#6b6b6b"}}></i>
                                </div>

                            </div>
                        </li>
                        <li>
                            <div className="see-all-voted">
                                <p>See all (20)</p>
                            </div>
                        </li>
                    </ul>

                    
                </div>
            </div>
    );

    let content1;
    
    Topx.ct_type === 'sg-pic' && ( content1 = SinglepicWithCap());
    Topx.ct_type === 'pic_w_vid' && (content1 = Vids() );
    Topx.ct_type === 'album' && (content1 = Album());
    Topx.ct_type === 'vote' && (content1 =  Vote() );
    Topx.ct_type === 'word' && (content1 = WordOnly());

    return (
        <>{content1}</>
    )

}