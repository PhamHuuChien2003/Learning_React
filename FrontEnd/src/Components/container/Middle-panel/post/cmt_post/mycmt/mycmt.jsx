import './mycmt.css'

export default function MyCmt() {

    const style1 = {
        'backgroundPosition': '0px -1143.5px',
        'backgroundSize': '26px 1550px',
        'width': '16px',
        'height': '16px',
        'backgroundRepeat': 'no-repeat', 
        'display': 'inline-block',
    }
    const style2 = {
        'backgroundPosition': '0px -1270px',
        'backgroundSize': '26px 1572px',
        'width': '16px',
        'height': '16px',
        'backgroundRepeat': 'no-repeat', 
        'display': 'inline-block',
    }
    const style3 = {
        'backgroundPosition': '0px -1197px',
        'backgroundSize': '26px 1572px',
        'width': '16px',
        'height': '16px',
        'backgroundRepeat': 'no-repeat', 
        'display': 'inline-block',
    }
    const style4 = {
        'backgroundPosition': '0px -1308px',
        'backgroundSize': '26px 1572px',
        'width': '16px',
        'height': '16px',
        'backgroundRepeat': 'no-repeat', 
        'display': 'inline-block',
    }
    
    const style5= {
        'backgroundPosition': '0px -1437px',
        'backgroundSize': '26px 1572px',
        'width': '16px',
        'height': '16px',
        'backgroundRepeat': 'no-repeat', 
        'display': 'inline-block',
    }


    return(
        <div className="my-cmt-section">
                        <div className="my-avt-in-cmt">
                            <img src="./images/avt/selfpic.jpg" alt=""/>
                            <div className="chevron-down" style={{'backgroundColor': 'var(--secondary-button-background)'}}>
                                <svg viewBox="0 0 16 16" width="1em" height="1em" fill="currentColor" className="chevron-down-svg">
                                    <g fillRule="evenodd" transform="translate(-448 -544)">
                                        <path fillRule="nonzero" d="M452.707 549.293a1 1 0 0 0-1.414 1.414l4 4a1 1 0 0 0 1.414 0l4-4a1 1 0 0 0-1.414-1.414L456 552.586l-3.293-3.293z">
                                        </path>
                                    </g>
                                </svg>
                            </div>
                        </div>
                        <div className="input-cmt">
                            <input type="text" placeholder="Write a public comment"/>
                            <div className="cmt-icon-butt">
                                <ul>
                                    <li>
                                        <i data-visualcompletion="css-img" className="x1b0d499 x1d69dk1" style={{backgroundImage: `url("./icon/fullicon.png")`,...style1}}></i>
                                    </li>
                                </ul>
                                <ul>
                                    <li>
                                        <i data-visualcompletion="css-img" className="x1b0d499 x1d69dk1" style={{backgroundImage: `url("./icon/fullicon.png")`,...style2}}></i>
                                    </li>
                                </ul>
                                <ul>
                                    <li>
                                        <i data-visualcompletion="css-img" className="x1b0d499 x1d69dk1" style={{backgroundImage: `url("./icon/fullicon.png")`,...style3}}></i>
                                    </li>
                                </ul>
                                <ul>
                                    <li>
                                        <i data-visualcompletion="css-img" className="x1b0d499 x1d69dk1" style={{backgroundImage: `url("./icon/fullicon.png")`,...style4}}></i>
                                    </li>
                                </ul>
                                <ul>
                                    <li>
                                        <i data-visualcompletion="css-img" className="x1b0d499 x1d69dk1" style={{backgroundImage: `url("./icon/fullicon.png")`,...style5}}></i>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
    )
}