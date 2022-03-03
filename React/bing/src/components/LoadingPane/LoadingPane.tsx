import React, { FC } from 'react';
import styles from './LoadingPane.module.scss';
import Spinner from "react-bootstrap/Spinner";
import LoadingPaneProps from './LoadingPaneProps';



const LoadingPane: FC<LoadingPaneProps> = ({ message, fullOverlay }:LoadingPaneProps) => (
  <div className={`${styles.description}${fullOverlay ? " " + styles.fullOverlay : null}`} data-testid="LoadingPane">
    <div className={styles.SpinnerContainer}>
      <Spinner animation="border" role="status" size="sm" className={styles.Spinner} />
      <span className={styles.Message}>{message}</span>
    </div>
  </div>
);

export default LoadingPane;
