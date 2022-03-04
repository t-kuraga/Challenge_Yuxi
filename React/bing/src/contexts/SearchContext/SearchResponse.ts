export interface QueryContext {
    originalQuery: string;
}

export interface License {
    name: string;
    url: string;
}

export interface ContractualRule {
    _type: string;
    targetPropertyName: string;
    targetPropertyIndex: number;
    mustBeCloseToContent: boolean;
    license: License;
    licenseNotice: string;
}

export interface Value {
    id: string;
    contractualRules: ContractualRule[];
    name: string;
    url: string;
    isFamilyFriendly: boolean;
    displayUrl: string;
    snippet: string;
    dateLastCrawled: Date;
    language: string;
    isNavigational: boolean;
}

export interface WebPages {
    webSearchUrl: string;
    totalEstimatedMatches: number;
    value: Value[];
    someResultsRemoved: boolean;
}

export interface SearchResponse {
    _type: string;
    queryContext: QueryContext;
    webPages: WebPages;
}