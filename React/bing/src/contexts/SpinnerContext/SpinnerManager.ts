/**
 * SpinnerManager
 */
 export default interface SpinnerManager {
    /**
     * Is spinner displayed
     */
    isSpinnerDisplayed: boolean;
    /**
     * Shows the spinner
     * @param {bool} hideContent Hide background content 
     * @param {string} message Spinner message
     */
    show: (hideContent?: boolean, message?: string) => void;
    /**
     * Hides the spinner
     */
    hide: () => void;
  
  }
  