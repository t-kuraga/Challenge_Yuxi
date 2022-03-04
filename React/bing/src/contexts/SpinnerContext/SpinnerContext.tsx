import React, { useContext, useState } from 'react';
import { useTranslation } from 'react-i18next';
import LoadingPane from '../../components/LoadingPane/LoadingPane.lazy';
import SpinnerManager from './SpinnerManager';

/**
 * Spinner provider properties
 */
export interface SpinnerProviderProps {
  children?: JSX.Element | JSX.Element[] | string
}

/**
 * Spinner context
 */
const SpinnerContext = React.createContext<SpinnerManager>(undefined!);


/**
* Spinner hook
* @returns Spinner context
*/
export function useSpinner(): SpinnerManager {
  return useContext(SpinnerContext)
}

/**
 * Spinner provider
 * @returns Component
 */
export default function SpinnerProvider({ children }: SpinnerProviderProps) {
  const { t } = useTranslation();
  const [showSpinner, setShowSpinner] = useState(false);
  const [hideContent, setHideContent] = useState(false);
  const [msg, setMessage] = useState<string>(t("Loading..."))

  // Context value
  const value: SpinnerManager = {
    isSpinnerDisplayed: showSpinner,
    show: (hideContent?: boolean, message?: string) => {
      setShowSpinner(true);
      setHideContent(!!hideContent);
      setMessage(message || message === "" ? message : t("Loading..."));
    },
    hide: () => {
      setShowSpinner(false);
      setHideContent(false);
    }
  };

  return (
    <SpinnerContext.Provider value={value}>
      {showSpinner && <LoadingPane message={msg} fullOverlay={hideContent} />}
      <div data-testid="ContentContainer" style={{ display: hideContent ? "none" : "block" }}>
        {children}
      </div>
    </SpinnerContext.Provider>
  )
}
