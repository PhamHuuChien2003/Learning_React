import "./Search-section.css"
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'


export default function SearchSection() {
	
	const placehoder ='Search Facebook';
	
	return(
		<>
		    <div className="search-section">
				<FontAwesomeIcon icon="fa-solid fa-magnifying-glass" style={{color: "#585c65",}} className="icon-search"/>
				<input type="text" placeholder="   Search Facebook" />
			</div>
		</>
	)
}
