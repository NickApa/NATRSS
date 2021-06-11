﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SpillTrackerCS.Tests.UnitTests
{
    class JsonStrings
    {
        public string MolecularweightJson, DensityJson, VaporPressureJson;
        public JsonStrings()
        {
            MolecularweightJson = "{\"PropertyTable\": {\"Properties\": [{\"CID\": 7847,\"MolecularWeight\": \"56.06\"}]}}";
            DensityJson = "{\"Record\":{\"RecordType\":\"CID\",\"RecordNumber\":222,\"RecordTitle\":\"Ammonia\",\"Section\":[{\"TOCHeading\":\"Chemical and Physical Properties\",\"Description\":\"Chemical and physical properties such as melting point, molecular weight, etc.\",\"Section\":[{\"TOCHeading\":\"Experimental Properties\",\"Description\":\"Properties determined experimentally (See also Safety and Hazard Properties section for more information if available)\",\"Section\":[{\"TOCHeading\":\"Density\",\"Description\":\"This section provides information on the density (with unit) and specific gravity (without unit) of a compound. Density is mass of a unit volume of a compound and commonly expressed in units of kg/m3 or g/cm3. Specific gravity, also known as relative density, is a unit-less quantity, defined as the ratio of the density of a compound to that of a standard reference material (typically, water at 4 \u00b0C for liquids and air at room temperature [20 \u00b0C or 68 \u00b0F] for gases).\",\"Information\":[{\"ReferenceNumber\":2,\"Reference\":[\"U.S. Environmental Protection Agency. 1998. Extremely Hazardous Substances (EHS) Chemical Profiles and Emergency First Aid Guides. Washington, D.C.: U.S. Government Printing Office.\"],\"Value\":{\"StringWithMarkup\":[{\"String\":\"0.6818 at -28.03 \u00b0F (EPA, 1998)\"}]}},{\"ReferenceNumber\":38,\"Description\":\"PEER REVIEWED\",\"Reference\":[\"Haynes, W.M. (ed.). CRC Handbook of Chemistry and Physics. 95th Edition. CRC Press LLC, Boca Raton: FL 2014-2015, p. 4-46\"],\"Value\":{\"StringWithMarkup\":[{\"String\":\"0.696 g/L (liquid)\"}]}},{\"ReferenceNumber\":40,\"Value\":{\"StringWithMarkup\":[{\"String\":\"Relative density (water = 1): 0.7 (-33 \u00b0C)\",\"Markup\":[{\"Start\":18,\"Length\":5,\"URL\":\"https://pubchem.ncbi.nlm.nih.gov/compound/water\",\"Type\":\"PubChem Internal Link\",\"Extra\":\"CID-962\"}]}]}},{\"ReferenceNumber\":57,\"Value\":{\"StringWithMarkup\":[{\"String\":\"0.6818 at -28.03\u00b0F\"}]}},{\"ReferenceNumber\":70,\"Value\":{\"StringWithMarkup\":[{\"String\":\"0.60(relative gas density)\"}]}}]}]}]}],\"Reference\":[{\"ReferenceNumber\":2,\"SourceName\":\"CAMEO Chemicals\",\"SourceID\":\"4860\",\"Name\":\"AMMONIA, ANHYDROUS\",\"Description\":\"CAMEO Chemicals is a chemical database designed for people who are involved in hazardous material incident response and planning. CAMEO Chemicals contains a library with thousands of datasheets containing response-related information and recommendations for hazardous materials that are commonly transported, used, or stored in the United States. CAMEO Chemicals was developed by the National Oceanic and Atmospheric Administration's Office of Response and Restoration in partnership with the Environmental Protection Agency's Office of Emergency Management.\",\"URL\":\"https://cameochemicals.noaa.gov/chemical/4860\",\"LicenseNote\":\"CAMEO Chemicals and all other CAMEO products are available at no charge to those organizations and individuals (recipients) responsible for the safe handling of chemicals. However, some of the chemical data itself is subject to the copyright restrictions of the companies or organizations that provided the data.\",\"LicenseURL\":\"https://cameochemicals.noaa.gov/help/reference/terms_and_conditions.htm?d_f=false\",\"ANID\":756675},{\"ReferenceNumber\":38,\"SourceName\":\"Hazardous Substances Data Bank (HSDB)\",\"SourceID\":\"162\",\"Name\":\"Ammonia\",\"Description\":\"The Hazardous Substances Data Bank (HSDB) is a toxicology database that focuses on the toxicology of potentially hazardous chemicals. It provides information on human exposure, industrial hygiene, emergency handling procedures, environmental fate, regulatory requirements, nanomaterials, and related areas. The information in HSDB has been assessed by a Scientific Review Panel.\",\"URL\":\"https://pubchem.ncbi.nlm.nih.gov/source/hsdb/162\",\"IsToxnet\":true,\"ANID\":122},{\"ReferenceNumber\":40,\"SourceName\":\"ILO International Chemical Safety Cards (ICSC)\",\"SourceID\":\"0414\",\"Name\":\"AMMONIA (ANHYDROUS)\",\"Description\":\"International Chemical Safety Cards (ICSC) are data sheets intended to provide essential safety and health information on chemicals in a clear and concise way.\",\"URL\":\"https://www.ilo.org/dyn/icsc/showcard.display?p_version=2&p_card_id=0414\",\"LicenseNote\":\"The reproduction of ILO material is generally authorized for non-commercial purposes and within established limits. For non-commercial purposes of reproduction of data, any required permission is hereby granted and no further permission must be obtained from the ILO, but acknowledgement to the ILO as the original source must be made.\",\"LicenseURL\":\"https://www.ilo.org/global/copyright/request-for-permission/lang--en/index.htm\",\"ANID\":2260318},{\"ReferenceNumber\":57,\"SourceName\":\"Occupational Safety and Health Administration (OSHA)\",\"SourceID\":\"623\",\"Name\":\"AMMONIA\",\"Description\":\"The OSHA Occupational Chemical Database contains over 800 entries with information such as physical properties, exposure guidelines, etc.\",\"URL\":\"http://www.osha.gov/chemicaldata/chemResult.html?RecNo=623\",\"LicenseNote\":\"Materials created by the federal government are generally part of the public domain and may be used, reproduced and distributed without permission. Therefore, content on this website which is in the public domain may be used without the prior permission of the U.S. Department of Labor (DOL). Warning: Some content - including both images and text - may be the copyrighted property of others and used by the DOL under a license.\",\"LicenseURL\":\"https://www.dol.gov/general/aboutdol/copyright\",\"ANID\":3411099},{\"ReferenceNumber\":70,\"SourceName\":\"The National Institute for Occupational Safety and Health (NIOSH)\",\"SourceID\":\"npgd0028\",\"Name\":\"Ammonia\",\"Description\":\"The NIOSH Pocket Guide to Chemical Hazards is intended as a source of general industrial hygiene information on several hundred chemicals/classes for workers, employers, and occupational health professionals. Read more: https://www.cdc.gov/niosh/npg/\",\"URL\":\"https://www.cdc.gov/niosh/npg/npgd0028.html\",\"LicenseNote\":\"The information provided using CDC Web site is only intended to be general summary information to the public. It is not intended to take the place of either the written law or regulations.\",\"LicenseURL\":\"https://www.cdc.gov/Other/disclaimer.html\",\"ANID\":2266328}]}}";
            VaporPressureJson = "{\"Record\":{\"RecordType\":\"CID\",\"RecordNumber\":222,\"RecordTitle\":\"Ammonia\",\"Section\":[{\"TOCHeading\":\"Chemical and Physical Properties\",\"Description\":\"Chemical and physical properties such as melting point, molecular weight, etc.\",\"Section\":[{\"TOCHeading\":\"Experimental Properties\",\"Description\":\"Properties determined experimentally (See also Safety and Hazard Properties section for more information if available)\",\"Section\":[{\"TOCHeading\":\"Vapor Pressure\",\"Description\":\"Vapor pressure is the pressure of a vapor in thermodynamic equilibrium with its condensed phases in a closed system.\",\"Information\":[{\"ReferenceNumber\":2,\"Reference\":[\"U.S. Environmental Protection Agency. 1998. Extremely Hazardous Substances (EHS) Chemical Profiles and Emergency First Aid Guides. Washington, D.C.: U.S. Government Printing Office.\"],\"Value\":{\"StringWithMarkup\":[{\"String\":\"400 mm Hg at -49.72 \u00b0F (EPA, 1998)\"}]}},{\"ReferenceNumber\":38,\"Description\":\"PEER REVIEWED\",\"Reference\":[\"Daubert TE, Danner RP;  Physical and Thermodynamic Properties of Pure Chemicals: Data Compilation.  Design Institute for Physical Property Data, American Institute of Chemical Engineers. New York, NY: Hemisphere Pub Corp (1999)\"],\"Value\":{\"StringWithMarkup\":[{\"String\":\"7500 mm Hg at 25 \u00b0C\"}]}},{\"ReferenceNumber\":40,\"Value\":{\"StringWithMarkup\":[{\"String\":\"Vapor pressure, kPa at 26 \u00b0C: 1013\"}]}},{\"ReferenceNumber\":57,\"Value\":{\"StringWithMarkup\":[{\"String\":\"8.5 atm\"}]}},{\"ReferenceNumber\":70,\"Value\":{\"StringWithMarkup\":[{\"String\":\"8.5 atm\"}]}}]}]}]}],\"Reference\":[{\"ReferenceNumber\":2,\"SourceName\":\"CAMEO Chemicals\",\"SourceID\":\"4860\",\"Name\":\"AMMONIA, ANHYDROUS\",\"Description\":\"CAMEO Chemicals is a chemical database designed for people who are involved in hazardous material incident response and planning. CAMEO Chemicals contains a library with thousands of datasheets containing response-related information and recommendations for hazardous materials that are commonly transported, used, or stored in the United States. CAMEO Chemicals was developed by the National Oceanic and Atmospheric Administration's Office of Response and Restoration in partnership with the Environmental Protection Agency's Office of Emergency Management.\",\"URL\":\"https://cameochemicals.noaa.gov/chemical/4860\",\"LicenseNote\":\"CAMEO Chemicals and all other CAMEO products are available at no charge to those organizations and individuals (recipients) responsible for the safe handling of chemicals. However, some of the chemical data itself is subject to the copyright restrictions of the companies or organizations that provided the data.\",\"LicenseURL\":\"https://cameochemicals.noaa.gov/help/reference/terms_and_conditions.htm?d_f=false\",\"ANID\":756675},{\"ReferenceNumber\":38,\"SourceName\":\"Hazardous Substances Data Bank (HSDB)\",\"SourceID\":\"162\",\"Name\":\"Ammonia\",\"Description\":\"The Hazardous Substances Data Bank (HSDB) is a toxicology database that focuses on the toxicology of potentially hazardous chemicals. It provides information on human exposure, industrial hygiene, emergency handling procedures, environmental fate, regulatory requirements, nanomaterials, and related areas. The information in HSDB has been assessed by a Scientific Review Panel.\",\"URL\":\"https://pubchem.ncbi.nlm.nih.gov/source/hsdb/162\",\"IsToxnet\":true,\"ANID\":122},{\"ReferenceNumber\":40,\"SourceName\":\"ILO International Chemical Safety Cards (ICSC)\",\"SourceID\":\"0414\",\"Name\":\"AMMONIA (ANHYDROUS)\",\"Description\":\"International Chemical Safety Cards (ICSC) are data sheets intended to provide essential safety and health information on chemicals in a clear and concise way.\",\"URL\":\"https://www.ilo.org/dyn/icsc/showcard.display?p_version=2&p_card_id=0414\",\"LicenseNote\":\"The reproduction of ILO material is generally authorized for non-commercial purposes and within established limits. For non-commercial purposes of reproduction of data, any required permission is hereby granted and no further permission must be obtained from the ILO, but acknowledgement to the ILO as the original source must be made.\",\"LicenseURL\":\"https://www.ilo.org/global/copyright/request-for-permission/lang--en/index.htm\",\"ANID\":2260318},{\"ReferenceNumber\":57,\"SourceName\":\"Occupational Safety and Health Administration (OSHA)\",\"SourceID\":\"623\",\"Name\":\"AMMONIA\",\"Description\":\"The OSHA Occupational Chemical Database contains over 800 entries with information such as physical properties, exposure guidelines, etc.\",\"URL\":\"http://www.osha.gov/chemicaldata/chemResult.html?RecNo=623\",\"LicenseNote\":\"Materials created by the federal government are generally part of the public domain and may be used, reproduced and distributed without permission. Therefore, content on this website which is in the public domain may be used without the prior permission of the U.S. Department of Labor (DOL). Warning: Some content - including both images and text - may be the copyrighted property of others and used by the DOL under a license.\",\"LicenseURL\":\"https://www.dol.gov/general/aboutdol/copyright\",\"ANID\":3411099},{\"ReferenceNumber\":70,\"SourceName\":\"The National Institute for Occupational Safety and Health (NIOSH)\",\"SourceID\":\"npgd0028\",\"Name\":\"Ammonia\",\"Description\":\"The NIOSH Pocket Guide to Chemical Hazards is intended as a source of general industrial hygiene information on several hundred chemicals/classes for workers, employers, and occupational health professionals. Read more: https://www.cdc.gov/niosh/npg/\",\"URL\":\"https://www.cdc.gov/niosh/npg/npgd0028.html\",\"LicenseNote\":\"The information provided using CDC Web site is only intended to be general summary information to the public. It is not intended to take the place of either the written law or regulations.\",\"LicenseURL\":\"https://www.cdc.gov/Other/disclaimer.html\",\"ANID\":2266328}]}}";           
        }
    }
}
